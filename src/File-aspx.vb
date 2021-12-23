'Imports System
'Imports System.Collections
'Imports System.ComponentModel
'Imports System.Data
'Imports System.Drawing
'Imports System.Web
'Imports System.Web.SessionState
'Imports System.Web.UI
'Imports System.Web.UI.WebControls
'Imports System.Web.UI.HtmlControls

'Imports System.IO
'Imports System.Diagnostics
'Imports System.Xml
'Imports System.Xml.XPath
Imports System.Xml.Xsl

Public Class xmltohtmlForm
    Inherits Page

    Private Rutaxml As String = Server.MapPath("/") + "12empresas.xml.html"
    Private Rutaxsl As String = Server.MapPath("/") + "12empresas.xsl.html"
    Private Rutavb As String = Server.MapPath("/") + "xmltohtml.aspx.vb.html"
    Private Rutaxmlt As String = Server.MapPath("/") + "12empresas.xml"
    Private Rutaxslt As String = Server.MapPath("/") + "12empresas.xsl"
    Private Rutahtml As String = Server.MapPath("/") + "12empresas.html"

    'Otra manera de obtener la ruta a los archivos
    'Private Rutaxmlt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xml")).FullName
    'Private Rutaxslt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xsl")).FullName
    'Private Rutahtml As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.html")).FullName

#Region " Código generado por el Diseñador de Web Forms "

    'El Diseñador de Web Forms requiere esta llamada.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents Form1 As System.Web.UI.HtmlControls.HtmlForm
    Protected WithEvents Btverxml As System.Web.UI.WebControls.Button
    Protected WithEvents Btverxsl As System.Web.UI.WebControls.Button
    Protected WithEvents Btvervb As System.Web.UI.WebControls.Button
    Protected WithEvents Btconvertir As System.Web.UI.WebControls.Button
    Protected WithEvents Btverhtml As System.Web.UI.WebControls.Button

    'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
    'No se debe eliminar o mover.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
        'No la modifique con el editor de código.
        InitializeComponent()
    End Sub

#End Region

    Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'comprobación de rutas
        'Response.Write(Rutaxml + "<br>")
        'Response.Write(Rutaxsl + "<br>")
        'Response.Write(Rutavb + "<br>")
        'Response.Write(Rutahtml + "<br>")
    End Sub

    Sub Abrirxml(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btverxml.Click
        System.Diagnostics.Process.Start(Rutaxml) 'abre el archivo con el programa asociado de Windows
        'System.Diagnostics.Process.Start("Notepad.exe", Rutaxml) 'abre el archivo en Bloc de Notas
        'System.Diagnostics.Process.Start("IExplore.exe", Rutaxml) 'abre el archivo en Internet Explorer
        'Response.Redirect(Rutaxml)
    End Sub

    Sub Abrirxsl(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btverxsl.Click
        System.Diagnostics.Process.Start(Rutaxsl) 'abre el archivo con el programa asociado de Windows
        'System.Diagnostics.Process.Start("Notepad.exe", Rutaxsl) 'abre el archivo en Bloc de Notas
        'System.Diagnostics.Process.Start("IExplore.exe", Rutaxsl) 'abre el archivo en Internet Explorer
        'Response.Redirect(Rutaxsl)
    End Sub

    Sub Abrirtxt(ByVal sender As System.Object, ByVal e As System.EventArgs)
        System.Diagnostics.Process.Start(Rutavb) 'abre el archivo con el programa asociado de Windows
        'System.Diagnostics.Process.Start("Notepad.exe", Rutavb) 'abre el archivo en Bloc de Notas
        'System.Diagnostics.Process.Start("IExplore.exe", Rutavb) 'abre el archivo en Internet Explorer
        'Response.Redirect(Rutavb)
    End Sub

    Sub Convertir(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btconvertir.Click
        'XslCompiledTransform transforma un archivo XML de acuerdo 
        'con las reglas contenidas en una hoja de estilos XSL
        Dim xslt As System.Xml.Xsl.XslCompiledTransform = New XslCompiledTransform
        xslt.Load(Rutaxslt) 'carga y compila la hoja de estilos XSL
        xslt.Transform(Rutaxmlt, Rutahtml) 'ejecuta la transformación usando el documento 
        'xml del parámetro 1 creando el documento HTML del parámetro 2
        Btconvertir.Text = "Archivo XML convertido a HTML con transformación XLST"
    End Sub

    Sub Abrirhtml(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btverhtml.Click
        System.Diagnostics.Process.Start(Rutahtml) 'abre el archivo con el programa asociado de Windows
        'Response.Redirect(Rutahtml)
    End Sub

End Class
