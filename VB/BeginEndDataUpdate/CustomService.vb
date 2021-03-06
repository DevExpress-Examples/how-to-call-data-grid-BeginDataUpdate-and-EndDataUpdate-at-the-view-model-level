Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Grid
Imports System

Namespace BeginEndDataUpdate

    Public Interface ICustomService

        Sub BeginUpdate()

        Sub EndUpdate()

    End Interface

    Friend Class CustomService
        Inherits ServiceBase
        Implements ICustomService

        Private ReadOnly Property ActuaGridControl As GridControl
            Get
                Return TryCast(AssociatedObject, GridControl)
            End Get
        End Property

        Protected Overrides Sub OnAttached()
            If ActuaGridControl Is Nothing Then Throw New InvalidOperationException("This service can be attached only to the GridControl.")
            MyBase.OnAttached()
        End Sub

        Public Sub BeginUpdate() Implements ICustomService.BeginUpdate
            ActuaGridControl.BeginDataUpdate()
        End Sub

        Public Sub EndUpdate() Implements ICustomService.EndUpdate
            ActuaGridControl.EndDataUpdate()
        End Sub
    End Class
End Namespace
