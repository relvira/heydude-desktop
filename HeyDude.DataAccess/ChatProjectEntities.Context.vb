﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código se generó a partir de una plantilla.
'
'     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
'     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure

Partial Public Class ChatProjectEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ChatProjectEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property users() As DbSet(Of user)
    Public Overridable Property user_friends() As DbSet(Of user_friends)
    Public Overridable Property user_notifications() As DbSet(Of user_notifications)
    Public Overridable Property user_pending_messages() As DbSet(Of user_pending_messages)

End Class