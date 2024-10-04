Module Module1
    Public uname As String = ""
    Public Property flag As Integer
    Public Pname As String = ""
    Public c_year As Integer
    Public qty As Integer = 0

    Public invno As String = ""
    Public dk As New DataSet
    Public r_type As String = ""
    Public c_type As String = ""

    Public Sub AutoSearch(ByRef xcb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal blnLimitToList As Boolean)

        Dim strFindStr As String = ""

        If e.KeyChar = ChrW(8) Then

            If (xcb.SelectionStart <= 1) Then

                xcb.Text = ""
                Exit Sub
            End If

            If (xcb.SelectionLength = 0) Then

                strFindStr = xcb.Text.Substring(0, xcb.Text.Length - 1)

            Else

                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart - 1)
            End If

        Else

            If (xcb.SelectionLength = 0) Then

                strFindStr = xcb.Text + e.KeyChar

            Else

                strFindStr = xcb.Text.Substring(0, xcb.SelectionStart) + e.KeyChar
            End If

            Dim intIdx As Integer = -1
            ' Search the string in the ComboBox list.  

            intIdx = xcb.FindString(strFindStr)
            If (intIdx <> -1) Then

                xcb.SelectedText = ""
                xcb.SelectedIndex = intIdx
                xcb.SelectionStart = strFindStr.Length
                xcb.SelectionLength = xcb.Text.Length
                e.Handled = True

            Else

                e.Handled = blnLimitToList

            End If
        End If
    End Sub



    Function NumberInWords(num As String)
        'Constants are Defined
        Dim digit(100) As String
        digit(0) = ""
        digit(1) = "One "
        digit(2) = "Two "
        digit(3) = "Three "
        digit(4) = "Four "
        digit(5) = "Five "
        digit(6) = "Six "
        digit(7) = "Seven "
        digit(8) = "Eight "
        digit(9) = "Nine "
        digit(10) = "Ten "
        digit(11) = "Eleven "
        digit(12) = "Twelve "
        digit(13) = "Thirteen "
        digit(14) = "Fourteen "
        digit(15) = "Fifteen "
        digit(16) = "Sixteen "
        digit(17) = "Seventeen "
        digit(18) = "Eighteen "
        digit(19) = "Ninteen "
        digit(20) = "Twenty "
        digit(30) = "Thirty "
        digit(40) = "Fourty "
        digit(50) = "Fifty "
        digit(60) = "Sixty "
        digit(70) = "Seventy "
        digit(80) = "Eighty "
        digit(90) = "Ninty "
        digit(100) = "Hundred "
        Dim tt(5) As String
        tt(2) = "Thousand "
        tt(3) = "Lakh "
        tt(4) = "Crore "
        tt(5) = "Hundred Crore "
        'Separating the Whole Number and Digits
        Dim nn As String
        Dim dd As String = ""
        nn = Math.Round(Val(num), 2)
        If InStr(nn, ".") <> 0 Then
            dd = Mid(nn, InStr(nn, ".") + 1)
            nn = Mid(nn, 1, InStr(nn, ".") - 1)
        End If

        'Variable nn stores the whole number and dd stores the digits
        'Finding the Word for numbers

        Dim x As Integer
        Dim y As Integer = 0
        x = nn.Length - 1
        Dim z As String
        Dim str As String = ""
        Dim str1 As String = ""
        If x > 1 Then
            While (x > -1)
                'First Loop Last two digits of Number is evaluated(ones and Tens)
                If y = 0 Then
                    z = Mid(nn, x, 2)
                    If Val(z) < 21 And Val(z) > 0 Then
                        str = digit(Val(z))
                    ElseIf Val(z) > 0 Then
                        str = digit(Val(z(0)) * 10)
                        str = str & digit(Val(z(1)))
                    End If
                    x = x - 1
                End If


                'Second Loop 3rd digits of Number is evaluated(Hundred)

                If y = 1 Then
                    z = Mid(nn, x, 1)
                    If Val(z) <> 0 Then
                        str = digit(Val(z)) & "Hundred " & str
                    End If
                    x = x - 2
                End If

                'Subsequent Loop Next two digits sequence of Number is evaluated(Thousands,Lakhs,Crore,etc)


                If y > 1 Then
                    If x <> 0 Then
                        z = Mid(nn, x, 2)
                        If Val(z) < 21 And Val(z) > 0 Then
                            str = digit(Val(z)) & tt(y) & str
                        ElseIf Val(z) > 0 Then
                            str1 = digit(Val(z(0)) * 10)
                            str = str1 & digit(Val(z(1))) & tt(y) & str
                        End If
                        x = x - 2
                    Else
                        z = Mid(nn, 1, 1)
                        If Val(z) < 21 And Val(z) > 0 Then
                            str = digit(Val(z)) & tt(y) & str
                        ElseIf Val(z) > 0 Then
                            str1 = digit(Val(z(0)) * 10)
                            str = str1 & digit(Val(z(1))) & tt(y) & str
                        End If
                        x = -1
                    End If
                End If
                y = y + 1
            End While
        Else
            If Val(nn) < 21 And Val(nn) > 0 Then
                str = digit(Val(nn))
            ElseIf Val(nn) > 0 Then
                str = digit(Val(nn(0)) * 10)
                str = str & digit(Val(nn(1)))
            End If

            'str = digit(nn)

        End If
        If str = "" Then
            str = "Zero "
        End If
        str = str & "Rupees "

        'Digits are evaluated(Paise)

        If Val(dd) > 0 Then
            If dd.Length = 1 Then
                z = Val(dd) * 10
            Else
                z = dd
            End If

            If Val(z) < 21 And Val(z) > 0 Then
                str = str & "and " & digit(Val(z)) & "Paise"
            ElseIf Val(z) > 0 Then
                str1 = digit(Val(z(0)) * 10)
                str = str & "and " & str1 & digit(Val(z(1))) & "Paise"
            End If
        End If

        'Word string is returned

        NumberInWords = str
    End Function
End Module
