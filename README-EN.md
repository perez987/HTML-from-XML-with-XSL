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

(unfinished)
