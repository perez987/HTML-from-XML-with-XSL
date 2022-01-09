# XML + XSL Transform > > HTML, in Visual Studio 2017

<table>
	<tr><td align=center><img src=img/xml.png>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=img/xsl.png></td></tr>
	<tr><td><b>How to convert an XML document into an HTML document with formatting and layout defined in an XSL stylesheet, using Visual Studio 2017 and Visual Basic .NET language</b></td></tr>
</table>  

### Introduction

XML documents are plain text and their basic presentation lacks layout or formatting options. When opening it, we always see text structured according to the rules of the XML language. Sometimes you need to use XML data as source but present it in a certain way, for example for a mobile device or for the web. In these cases we can use XSL style sheets.

XSL (*extensible stylesheet language*) contains rules that allow extracting and formatting information from an XML file to be presented to the user. Within the XSL language exists XSLT (*XSL transformation*) used to transform XML documents. XSLT defines how an XML document will be converted into another type of document that can be of several types (PDF, HTML, JAVA, etc.) although the most common is HTML to be viewed in a Web browser.
In this exercise, an XSL stylesheet has been created in which it has been defined how to present the XML data source in a web page that can be printed by the user.

### XslCompiledTransform class of System.Xml.Xsl namespace

In this class we have 2 overloaded methods, `XslCompiledTransform.Load` and `XslCompiledTransform.Transform`, which work this way:

* `Load` loads and compiles the stylesheet to be used using the XSL document as a single parameter
* `Transform` executes the transformation using the XML document (parameter 1) and creating the HTML document (parameter 2).

```vbnet
Dim xslt As System.Xml.Xsl.XslCompiledTransform = New XslCompiledTransform
xslt.Load(Rutaxslt) 'carga y compila la hoja de estilos XSL
xslt.Transform(Rutaxmlt, Rutahtml)
'ejecuta la transformación usando el documento XML del parámetro 1 creando el documento HTML del parámetro 2
```

In this exercise 2 documents will be used: _12empresas.xml_ y _12empresas.xsl_ to obtain by code a third document _12empresas.html_.

### 12empresas.xml

```xml
<?xml version="1.0" encoding="UTF-8"?>
<Agenda>
  <Contactos>
    <Id>1</Id>
    <Nombre>Case Corp.</Nombre>
    <Telefono1>923659854</Telefono1>
    <Telefono2>169852985</Telefono2>
  </Contactos>
  <Contactos>
    <Id>2</Id>
    <Nombre>Data General Corp.</Nombre>
    <Telefono1>902365458</Telefono1>
    <Telefono2>223697120</Telefono2>
  </Contactos>
  <Contactos>
    <Id>3</Id>
    <Nombre>Eastman Kodak Co.</Nombre>
    <Telefono1>933696369</Telefono1>
    <Telefono2>258623589</Telefono2>
  </Contactos>
  <Contactos>
    <Id>4</Id>
    <Nombre>Eaton Corp.</Nombre>
    <Telefono1>965235898</Telefono1>
    <Telefono2>001544444</Telefono2>
  </Contactos>
  <Contactos>
    <Id>5</Id>
    <Nombre>Gateway Inc.</Nombre>
    <Telefono1>900326596</Telefono1>
    <Telefono2>001544444</Telefono2>
  </Contactos>
  <Contactos>
    <Id>6</Id>
    <Nombre>Paine Webber Group Inc.</Nombre>
    <Telefono1>932145785</Telefono1>
    <Telefono2>214585258</Telefono2>
  </Contactos>
  <Contactos>
    <Id>7</Id>
    <Nombre>Parker Hannifin Corp.</Nombre>
    <Telefono1>944444102</Telefono1>
    <Telefono2>224465668</Telefono2>
  </Contactos>
  <Contactos>
    <Id>8</Id>
    <Nombre>Reynolds Metals Co.</Nombre>
    <Telefono1>923659854</Telefono1>
    <Telefono2>221995416</Telefono2>
  </Contactos>
  <Contactos>
    <Id>9</Id>
    <Nombre>Tenet Healthcare Corp.</Nombre>
    <Telefono1>944444102</Telefono1>
    <Telefono2>258623589</Telefono2>
  </Contactos>
  <Contactos>
    <Id>10</Id>
    <Nombre>UniGroup Inc.</Nombre>
    <Telefono1>932665447</Telefono1>
    <Telefono2>155584598</Telefono2>
  </Contactos>
  <Contactos>
    <Id>11</Id>
    <Nombre>Union Pacific Resources Group Inc.</Nombre>
    <Telefono1>965235898</Telefono1>
    <Telefono2>002587455</Telefono2>
  </Contactos>
  <Contactos>
    <Id>12</Id>
    <Nombre>Xerox Corp.</Nombre>
    <Telefono1>932569857</Telefono1>
    <Telefono2>224465668</Telefono2>
  </Contactos>
</Agenda>
```

### 12empresas.xsl

```xml
<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:template match="/">
    <head>
      <title>Archivo XML - > documento HTML</title>
    </head>
    <html>
      <body style="font-family: Verdana; font-size: 10pt;">
        <div align="center">
          <h3>
            <u>ARCHIVO XML - > DOCUMENTO HTML</u>
          </h3>
          <table border="1" cellpadding="4" cellspacing="4" style="font-family: Verdana; font-size: 10pt;">
            <tr bgcolor="lightgrey">
              <td align="left">
                <b>
                  <font color="black">Id</font>
                </b>
              </td>
			  <td>
                <b>
                  <font color="black">Nombre de la empresa</font>
                </b>
              </td>
              <td width="100">
                <b>
                  <font color="black">Teléfono</font>
                </b>
              </td>
              <td width="100">
                <b>
                  <font color="black">Teléfono</font>
                </b>
              </td>
            </tr>
            <xsl:for-each select="Agenda/Contactos">
              <xsl:sort select="Nombre" order="ascending"></xsl:sort>
              <tr bgcolor="white">
                <td align="right">
                  <font color="black">
                    <xsl:value-of select="Id"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Nombre"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Telefono1"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Telefono2"></xsl:value-of>
                  </font>
                </td>
              </tr>
            </xsl:for-each>
          </table>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
```

### 12empresas.html

You get the file _12empresas.html_ that contains the same data as the XML file but formatted according to the XSL file.

![12empresas.html](img/xml_xsl-2.jpg?raw=true)

### Variables with file paths

String variables get file paths `Server.MapPath` that returns the physical path that corresponds to the specified virtual path.

```vbnet
Private Rutaxmlt As String = Server.MapPath("/") + "12empresas.xml"
Private Rutaxslt As String = Server.MapPath("/") + "12empresas.xsl"
Private Rutahtml As String = Server.MapPath("/") + "12empresas.html"
```

These paths could be obtained in different ways, here I just comment on another one that is somewhat more complex using _FileInfo Combine_ that combines the path defined in _Server.MapPath_ and the file name.

```vbnet
Private Rutaxmlt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xml")).FullName
Private Rutaxslt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xsl")).FullName
Private Rutahtml As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.html")).FullName
```

### XSL stylesheet

Note that this file mixes XML and HTML language. For example, HTML tags and attributes are used to build presentation and design of the web page.

```html
<table border="1" cellpadding="4" cellspacing="4" style="font-family: Verdana; font-size: 10pt;">
            <tr bgcolor="lightgrey">
              <td align="left">
                <b>
                  <font color="black">Id</font>
                </b>
              </td>
		<td>
                <b>
                  <font color="black">Company name</font>
                </b>
              </td>
              <td width="100">
                <b>
                  <font color="black">Phone</font>
                </b>
              </td>
              <td width="100">
                <b>
                  <font color="black">Phone</font>
                </b>
              </td>
            </tr>
```

Along with XML language that handles the data. Here _for-each_ loops are used to iterate through the elements of the XML file and _sort_ command to sort the data. The construction _<xsl:value-of select="Id">_ gets the value of the element of the same name in the XML file.

```xml
        <xsl:for-each select="Agenda/Contactos">
              <xsl:sort select="Nombre" order="ascending"></xsl:sort>
              <tr bgcolor="white">
                <td align="right">
                  <font color="black">
                    <xsl:value-of select="Id"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Name"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Phone"></xsl:value-of>
                  </font>
                </td>
                <td>
                  <font color="black">
                    <xsl:value-of select="Phone"></xsl:value-of>
                  </font>
                </td>
              </tr>
            </xsl:for-each>
```

### Open files with _System.Diagnostics.Process.Start_

As a complementary exercise, buttons have been created on the _aspx_ page to open each of the 3 used files, the XML source of the data, the XSL with the design  and the VB with the Visual Basic .NET code. To open the files,  _System.Diagnostics.Process.Start_ is ised, it starts a new process with the name of a file or an application:

* if it has 2 parameters, the first is the name of the program and the second the name of the file you want to open
* if it has only one parameter, it is the name of the file and, in this case, opens it with the program associated in Windows.

```vbnet
System.Diagnostics.Process.Start(Rutavb) 'abre el archivo con el programa asociado de Windows
System.Diagnostics.Process.Start("Notepad.exe", Rutavb) 'abre el archivo en Bloc de Notas
System.Diagnostics.Process.Start("IExplore.exe", Rutavb) 'abre el archivo en Internet Explorer
```
