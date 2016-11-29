Public Class frmMain
    Dim SelectedPicture As Bitmap : Dim GameTime As Integer : Dim ArrayImages As New ArrayList : Dim GamePicsQueue(,) As Integer
    Dim Rotatable As Boolean = False : Dim RowCount, ColCount As Integer : Dim DraggedPB As Integer
    Dim tmpDest, tmpSrc As String
    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChangeGameLevel(tsmiLevel1, e)
    End Sub
    Private Sub tsmiNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiNew.Click
        'ilk önce istenen resmi seçilir
        fdOpen.Filter = "Supported picture types|*.bmp;*.jpg;*.jpeg;*.png" : Dim DidWork As Integer = fdOpen.ShowDialog()
        If DidWork <> DialogResult.Cancel Then SelectedPicture = Bitmap.FromFile(fdOpen.FileName) Else Exit Sub
        'önceki resmi kutuları ve resim dizisi temizlenir ve yenileri oluşturulur
        PboxSelected.BackgroundImage = SelectedPicture : Call CreateNewGame()
    End Sub
    Private Sub tsmiExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiExit.Click
        Me.Close() 'exit game
    End Sub
    Private Sub ChangeGameLevel(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiLevel1.Click, tsmiLevel2.Click, tsmiLevel3.Click, tsmiLevel4.Click, tsmiLevel5.Click
        tsmiLevel1.Checked = False : tsmiLevel2.Checked = False : tsmiLevel3.Checked = False : tsmiLevel4.Checked = False : tsmiLevel5.Checked = False
        Select Case sender.ToString
            Case "Level 1" : tsmiLevel1.Checked = True : RowCount = 3 : ColCount = 3
            Case "Level 2" : tsmiLevel2.Checked = True : RowCount = 4 : ColCount = 4
            Case "Level 3" : tsmiLevel3.Checked = True : RowCount = 5 : ColCount = 5
            Case "Level 4" : tsmiLevel4.Checked = True : RowCount = 6 : ColCount = 6
            Case "Level 5" : tsmiLevel5.Checked = True : RowCount = 7 : ColCount = 7
        End Select
        tsmiLevel.Text = sender.ToString : Call CreateNewGame()
    End Sub
    Private Sub tsmiRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiRotate.Click
        If tsmiRotate.Checked = False Then tsmiRotate.Checked = True : Rotatable = True Else tsmiRotate.Checked = False : Rotatable = False
        Call CreateNewGame()
    End Sub
    Private Sub tsmiShowHint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiShowHint.Click
        If SelectedPicture Is Nothing Or tsmiShowHint.Text = "Game over" Then Exit Sub
        If tsmiShowHint.Text = "Show Hint" Then PboxSelected.Visible = True : tsmiShowHint.Text = "Hide Hint" Else PboxSelected.Visible = False : tsmiShowHint.Text = "Show Hint"
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim GameMin As String = Math.Floor(Convert.ToDouble(GameTime / 60)).ToString.PadLeft(2, "0")
        Dim GameSec As String = Math.Floor(Convert.ToDouble(GameTime Mod 60)).ToString.PadLeft(2, "0")
        lblStatus.Text = "Your time: " + GameMin + ":" + GameSec : GameTime += 1
    End Sub
    Private Sub CreateNewGame()
        Call ClearImages() : If SelectedPicture Is Nothing Then lblStatus.Text = "Select a picture to start" Else Call CreateImages()
        PboxSelected.SetBounds(10, 40, ColCount * 90 - 10, RowCount * 90 - 10) 'seçilen resim bir kutuya atılır daha sonra göstermek için
    End Sub
#Region "Image Procedures"
    Private Sub ClearImages()
        Dim PictureBoxes() As Label : Dim TotalPictures As Integer : PboxSelected.Image = Nothing
        For Each Pbox As Control In Me.Controls 'tüm picturebox kutularını bir diziye atıyor, ve sonra da siliyor
            If Pbox.Name = "GamePictureBtn" Then ReDim Preserve PictureBoxes(TotalPictures) : PictureBoxes(TotalPictures) = Pbox : TotalPictures = TotalPictures + 1
        Next
        For i = 0 To TotalPictures - 1
            Me.Controls.Remove(PictureBoxes(i))
        Next i 'şimdi formdaki tüm elemanlar ilk hallerine geri döndürülüyor
        Timer1.Enabled = False : GameTime = 0 : ArrayImages.Clear() : If tsmiShowHint.Text <> "Show Hint" Then tsmiShowHint_Click(tsmiShowHint, System.EventArgs.Empty)
    End Sub
    Private Sub CreateImages()
        Dim GamePictureBtn As Label : Dim tmp As Integer = 0 : Dim yatay, dikey, i, j, k As Integer : Dim GamePics(ColCount * RowCount - 1) As Bitmap : ReDim GamePicsQueue(ColCount * RowCount - 1, 1)
        Dim tmpPicture As Bitmap = ResizeImage(SelectedPicture, ColCount / SelectedPicture.Width * 80, RowCount / SelectedPicture.Height * 80)
        Try 'seçilen resim 80x80 parçalara bölünür ve parçalar bir değişken diziye aktarılır
            For k = 0 To (ColCount * RowCount - 1)
                Dim tmpNewPicture As New Bitmap(80, 80)
                For i = 0 To 79
                    For j = 0 To 79
                        tmpNewPicture.SetPixel(i, j, tmpPicture.GetPixel(i + yatay, j + dikey))
                    Next
                Next
                GamePics(k) = tmpNewPicture
                ArrayImages.Add(tmpNewPicture) : yatay += 80 : If yatay = ColCount * 80 Then yatay = 0 : dikey += 80 'sayfada maksimum sütün sayısına göre genişliği geçmişse
            Next
        Catch ex As Exception 'birşey olur da hata yaparsa program
            MsgBox("Choose a different picture!", , "Error opening picture") : Exit Sub
        End Try
        Shuffle(ArrayImages, k, 7) 'dizi karıştırılır
        For k = 0 To (ColCount * RowCount - 1)
            For i = 0 To (ColCount * RowCount - 1)
                If ArrayImages(k).Equals(GamePics(i)) Then GamePicsQueue(k, 0) = i : GamePicsQueue(k, 1) = 0 : Exit For
            Next
        Next
        For i = 0 To RowCount - 1 'dizideki eleman sayısınca picturebox oluşturulur ve içlerine resimler yapıştırılır
            For j = 0 To ColCount - 1 'istenilen sıra ve sütun sayısına göre picturebox oluşturuyor
                GamePictureBtn = New Label : GamePictureBtn.Parent = Me : GamePictureBtn.Visible = True
                GamePictureBtn.Name = "GamePictureBtn" : GamePictureBtn.BorderStyle = BorderStyle.Fixed3D : GamePictureBtn.Tag = tmp
                GamePictureBtn.SetBounds(90 * j + 10, 90 * i + 40, 80, 80) : GamePictureBtn.Image = ArrayImages(tmp) : tmp += 1
                If Rotatable = True Then RotateImages(GamePictureBtn) 'döndürülsün seçilmişse rastgele resimleri döndürür
                AddHandler GamePictureBtn.DoubleClick, AddressOf GamePictures_DoubleClick 'pictureboxların eventleri
            Next j
        Next i
        GamePictureBtn.Image = imageList1.Images(0) : GamePictureBtn.BorderStyle = BorderStyle.None : DraggedPB = tmp - 1
        Me.Width = ColCount * 90 + 30 : Me.Height = RowCount * 90 + 100 : Timer1.Enabled = True : Call Timer1_Tick(tsmiLevel1, System.EventArgs.Empty) 'formun büyüklüğü düzeltiliyor
    End Sub
    Private Sub RotateImages(ByVal DestinationPictureBox As Label, Optional ByVal RandomRotation As Boolean = True)
        Dim tmpDegree As Integer
        If RandomRotation = True Then tmpDegree = CInt(Rnd() * 4) Else tmpDegree = 1
        Select Case tmpDegree
            Case 1 : DestinationPictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case 2 : DestinationPictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case 3 : DestinationPictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
        End Select
        Dim x As Integer = GamePicsQueue(DestinationPictureBox.Tag, 1) + (tmpDegree * 90) : If x = 360 Then x = 0
        GamePicsQueue(DestinationPictureBox.Tag, 1) = x : Me.Refresh()
    End Sub
    Private Function ResizeImage(ByVal PictureImage As Image, ByVal WidthScaleFactor As Single, ByVal HeightScaleFactor As Single) As Image
        Dim bmpDestination As New Bitmap(CInt(PictureImage.Width * WidthScaleFactor), CInt(PictureImage.Height * HeightScaleFactor))
        Dim GrDestination As Graphics = Graphics.FromImage(bmpDestination)
        GrDestination.DrawImage(PictureImage, 0, 0, bmpDestination.Width + 1, bmpDestination.Height + 1)
        Return bmpDestination
    End Function
    Private Sub Shuffle(ByRef arrayToBeShuffled As ArrayList, ByVal ArrayLength As Integer, ByVal numberOfTimesToShuffle As Integer)
        Dim rndPosition As New Random(DateTime.Now.Millisecond)
        For i As Integer = 1 To numberOfTimesToShuffle
            For i2 As Integer = 1 To ArrayLength
                swap(arrayToBeShuffled(rndPosition.Next(0, ArrayLength)), arrayToBeShuffled(rndPosition.Next(0, ArrayLength)))
            Next i2
        Next i
    End Sub
    Private Sub swap(ByRef arg1 As Object, ByRef arg2 As Object)
        Dim strTemp As Bitmap : strTemp = arg1 : arg1 = arg2 : arg2 = strTemp
    End Sub
    Private Sub CheckEndOfGame()
        For i = 0 To ColCount * RowCount - 1
            If GamePicsQueue(i, 0) <> i Then Exit Sub
            If GamePicsQueue(i, 1) <> 0 Then Exit Sub
        Next
        PboxSelected.Visible = True : Timer1.Enabled = False : tsmiShowHint.Text = "Game over" : MsgBox("bravo!")
    End Sub
#End Region
#Region "Image Label Events"
    Private Sub GamePictures_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Rotatable = True Then RotateImages(sender, False)
    End Sub
    Private Sub frmMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim tmpImage1, tmpImage2 As Label : Dim tmp As Integer = 0
        Select Case e.KeyCode
            Case 37 'sol ok tuşuna basınca sağdaki resim soldaki boşuğa gidecek
                If DraggedPB Mod ColCount = ColCount - 1 Then Exit Sub 'daha sağda resim yoksa işlem yapma
                For Each Pbox As Control In Me.Controls
                    If Pbox.Name = "GamePictureBtn" Then
                        If tmp = DraggedPB + 1 Then tmpImage1 = Pbox
                        If tmp = DraggedPB Then tmpImage2 = Pbox
                        tmp += 1
                    End If
                Next : DraggedPB += 1
            Case 38 'yukarı ok tuşuna basınca aşağıdaki resim yukarıdaki boşluğa gidecek
                If (RowCount * ColCount - 1) < (RowCount + DraggedPB) Then Exit Sub 'daha aşağıda resim yoksa işlem yapma
                For Each Pbox As Control In Me.Controls
                    If Pbox.Name = "GamePictureBtn" Then
                        If tmp = DraggedPB + RowCount Then tmpImage1 = Pbox
                        If tmp = DraggedPB Then tmpImage2 = Pbox
                        tmp += 1
                    End If
                Next : DraggedPB += RowCount
            Case 39 'sağ ok tuşuna basınca soldaki resim sağdaki boşluğa gidecek
                If DraggedPB Mod ColCount = 0 Then Exit Sub 'daha solda resim yoksa işlem yapma
                For Each Pbox As Control In Me.Controls
                    If Pbox.Name = "GamePictureBtn" Then
                        If tmp = DraggedPB - 1 Then tmpImage1 = Pbox
                        If tmp = DraggedPB Then tmpImage2 = Pbox
                        tmp += 1
                    End If
                Next : DraggedPB -= 1
            Case 40 'aşağı ok tuşuna basınca yukarıdaki resim aşağıdaki boşluğa gidecek
                If DraggedPB < RowCount Then Exit Sub 'daha yukarıda resim yoksa işlem yapma
                For Each Pbox As Control In Me.Controls
                    If Pbox.Name = "GamePictureBtn" Then
                        If tmp = DraggedPB - RowCount Then tmpImage1 = Pbox
                        If tmp = DraggedPB Then tmpImage2 = Pbox
                        tmp += 1
                    End If
                Next : DraggedPB -= RowCount
        End Select
        Dim tmpImageBox As New Label : tmpImageBox.Parent = Me : tmpImageBox.Visible = True : tmpImageBox.BorderStyle = BorderStyle.Fixed3D
        tmpImageBox.Image = tmpImage1.Image : tmpImage1.Image = tmpImage2.Image
        tmpImageBox.SetBounds(tmpImage1.Left, tmpImage1.Top, 80, 80) : tmpImage1.Visible = False : tmpImage2.Visible = False
        For i = 0 To 30
            Select Case e.KeyCode
                Case 37 'sol ok tuşuna basınca sağdaki resim soldaki boşuğa gidecek
                    tmpImageBox.Left -= 3
                Case 38 'yukarı ok tuşuna basınca aşağıdaki resim yukarıdaki boşluğa gidecek
                    tmpImageBox.Top -= 3
                Case 39 'sağ ok tuşuna basınca soldaki resim sağdaki boşluğa gidecek
                    tmpImageBox.Left += 3
                Case 40 'aşağı ok tuşuna basınca yukarıdaki resim aşağıdaki boşluğa gidecek
                    tmpImageBox.Top += 3
            End Select : Me.Refresh()
        Next
        tmpImage2.Image = tmpImageBox.Image : tmpImage1.Visible = True : tmpImage2.Visible = True : Me.Controls.Remove(tmpImageBox)
        tmpImage2.BorderStyle = BorderStyle.Fixed3D : tmpImage1.BorderStyle = BorderStyle.None
        Dim tmpTag As String = GamePicsQueue(tmpImage1.Tag, 0) : GamePicsQueue(tmpImage1.Tag, 0) = GamePicsQueue(tmpImage2.Tag, 0) : GamePicsQueue(tmpImage2.Tag, 0) = tmpTag
        Call CheckEndOfGame()
    End Sub
#End Region
End Class
