Imports WHLClasses
Imports WHLClasses.Linnworks.Orders
Imports WHLClasses.Orders

Public Class ResetOrderForm
    Dim Loader As New GenericDataController
    Private Sub ResetToNew_Click(sender As Object, e As EventArgs) Handles ResetToNew.Click 'Click button / Hit enter, either or.
        Dim SelectedOrder As ExtendedOrder 'Let's get our order
        Try
            SelectedOrder = Loader.LoadOrdex("T:\AppData\Orders\" + OrderNumTB.Text + ".ordex") 'Load it
            'Confirm the user wants to reset this item.
            If MsgBox("Order number " + OrderNumTB.Text + " has been found. Its current state is " + SelectedOrder.Status.ToString + ". Are you sure you want to reset this order to _New?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                SelectedOrder.SetStatus(OrderStatus._New) 'Set it to new
                SelectedOrder.issues.Clear()
                Loader.SaveDataToFile(OrderNumTB.Text + ".ordex", SelectedOrder, "T:\AppData\Orders") 'Framework seems to add the \ between the path and item automatically.
                MsgBox("Order " + OrderNumTB.Text + " has been reset")
                OrderNumTB.Clear() 'Clear the text box, whatever it is, we're done with it here.
            End If
        Catch ex As System.IO.FileNotFoundException 'File not found handling
            MsgBox("That file doesn't exist.")
        Catch ex2 As System.ArgumentException 'Someone typed $£%^&*()_ into the box. How silly.
            MsgBox("File names are only composed of 7 consecutive numbers.")
        End Try
        'Do not clear the box yet, it could have been a mistype.
        OrderNumTB.Focus() 'Focus box.
    End Sub

    Private Sub OrderNumTB_KeyPressed(sender As Object, e As KeyEventArgs) Handles OrderNumTB.KeyDown 'Pressing enter? Trigger the above function.
        If e.KeyCode = Keys.Enter Then
            ResetToNew_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CheckTrayFiles(OrderNumber As String)
        Dim trayToReturn As String = ""
        Dim orderRemovedFromTrays As Boolean = False
        'Load .TRS file
        Dim traylist As Trays = Loader.LoadAnything("T:\Appdata\Trays\.trs").Value
        'Check .TRS data for Order
        For Each miniTray As MiniTrayData In traylist
            For Each orderInMiniTray As String In miniTray.OrderIds
                'If it's found
                If OrderNumber = orderInMiniTray Then
                    'get the tray number.
                    trayToReturn = miniTray.Code
                    'Load the .OTR
                    Dim loadedTray As Tray = Loader.LoadTray("T:\Appdata\Trays\" + trayToReturn + ".otr")
                    'Remove order data from .otr and .trs
                    orderInMiniTray = Nothing
                    For Each orderInTray As TrayOrder In loadedTray.Orders
                        If OrderNumber = orderInTray.TruncatedOrderData.OrderId Then
                            orderInTray = Nothing
                        End If
                    Next
                    'Save .otr and .trs
                    Loader.SaveDataToFile(".otr", loadedTray, "T:\Appdata\Trays")
                    Loader.SaveDataToFile(".trs", traylist, "T:\Appdata\Trays")
                    orderRemovedFromTrays = True
                End If
            Next
        Next

        If orderRemovedFromTrays Then
            MsgBox("Removed order from tray " + trayToReturn.Replace("TR", "") + ".")
        Else
            MsgBox("Could not find any trays with this order.")
        End If
    End Sub
End Class
