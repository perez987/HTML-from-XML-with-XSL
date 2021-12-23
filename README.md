# Transformación XML + XSL >> HTML, en Visual Studio 2017

<table>
  <tr><td align=center><img src=xml.png>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=xsl.png></td></tr>
  <tr><td><b>Convertir un documento XML en un documento HTML con formato y diseño definidos en una hoja de estilos XSL, utilizando Visual Studio 2017 y lenguaje Visual Basic .NET</b></td></tr>
</table>  

### Introducción

Los documentos XML son de texto plano y su presentación básica carece de opciones de diseño o formato. Al abrirlo siempre vemos texto estructurado de acuerdo con las normas del lenguaje XML. En ocasiones se necesita utilizar datos XML como origen pero presentarlos de una manera determinada, por ejemplo para un dispositivo móvil o para la web. En estos casos podemos recurrir a las hojas de estilo XSL.

XSL (_extensible stylesheet language_) contiene las reglas que permiten extraer y formatear la información desde un archivo XML para ser presentada al usuario. Dentro del lenguaje XSL existe XSLT (_XSL transformation_) que se usa para transformar documentos XML. Mediante XSLT se define cómo va a ser convertido un documento XML en otro tipo de documento que puede ser de varios tipos (PDF, HTML, JAVA, etc.) aunque lo más habitual es que sea HTML para poder ser visualizado en un navegador Web.
Para conseguirlo hay que relacionar el documento XML con una hoja de estilos XSL en la que se detallan las reglas para transformar un tipo de documento en otro, estas reglas son analizadas por el procesador XSL y la salida resultante es un documento HTML formateado con arreglo a esas reglas.
En este ejercicio se ha creado una hoja de estilos XSL en la que se ha definido cómo presentar el origen de datos XML en una página Web apta para ser imprimida por el usuario.

### Clase XslCompiledTransform del espacio de nombres System.Xml.Xsl

En esta clase disponemos de 2 métodos sobrecargados, XslCompiledTransform.Load y XslCompiledTransform.Transform, que funcionan de esta manera:

* `Load` carga y compila la hoja de estilos que va a ser utilizada usando el documento XSL como parámetro único
* `Transform` ejecuta la transformación usando el documento XML (parámetro 1) y creando el documento HTML (parámetro 2).

```vbnet
Dim xslt As System.Xml.Xsl.XslCompiledTransform = New XslCompiledTransform
xslt.Load(Rutaxslt) 'carga y compila la hoja de estilos XSL'
xslt.Transform(Rutaxmlt, Rutahtml)
'ejecuta la transformación usando el documento XML del parámetro 1 creando el documento HTML del parámetro 2
```

En este ejercicio se van a utilizar 2 documentos: _12empresas.xml_ y _12empresas.xsl_ para obtener por código un tercer documento _12empresas.html_.

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

Se obtiene el archivo _12empresas.html_ que contiene los mismos datos que el archivo XML pero formateados según el archivo XSL.

![12empresas.html](xml_xsl-2.jpg?raw=true)

### Variables con las rutas a los archivos

Se crean unas variables de cadena que obtienen las rutas a los archivos utilizando Server.MapPath que devuelve la ruta física que se corresponde con la ruta virtual especificada.

```vbnet
Private Rutaxmlt As String = Server.MapPath("/") + "12empresas.xml"
Private Rutaxslt As String = Server.MapPath("/") + "12empresas.xsl"
Private Rutahtml As String = Server.MapPath("/") + "12empresas.html"
```

Estas rutas se podrían obtener de varias maneras diferentes, aquí sólo comento otra que es algo más compleja usando _Combine_ de -FileInfo_ que combina la ruta definida en _Server.MapPath_ con el nombre del archivo.

```vbnet
Private Rutaxmlt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xml")).FullName
Private Rutaxslt As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.xsl")).FullName
Private Rutahtml As String = New System.IO.FileInfo(System.IO.Path.Combine(Server.MapPath("/"), "12empresas.html")).FullName
```

Con ellas se programa el método que transforma el archivo XML en HTML, lo tienes en el primer bloque de código del articulo.

### Hoja de estilos XSL

Observa que en este archivo se mezclan lenguaje XML y HTML. Por ejemplo, se usan etiquetas y atributos HTML para diseñar la presentación de la página web.

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
```

Junto con lenguaje XML que maneja los datos. Aquí se usan bucles _for-each_ para iterar por los elementos del archivo XML y el comando _sort_ para ordenar los datos. La construcción _<xsl:value-of select="Id">_ conecta con los valores del elemento del mismo nombre del archivo XML.

Junto con lenguaje XML que maneja los datos. Aquí se usan bucles _for-each_ para iterar por los elementos del archivo XML y el comando _sort_ para ordenar los datos. La construcción _<xsl:value-of select="Id">_ conecta con los valores del elemento del mismo nombre del archivo XML.

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
```

### Abrir archivos con _System.Diagnostics.Process.Start_

Como ejercicio complementario se han creado unos botones en la página _aspx_ para abrir cada uno de los 3 archivos que se usan, el XML origen de los datos, el XSL con las normas de diseño y el VB con el código Visual Basic .NET. Para abrir los archivos se usa _System.Diagnostics.Process.Start_ que inicia un proceso nuevo con el nombre de un archivo o una aplicación:

* si lleva 2 parámetros, el primero es el nombre del programa y el segundo el nombre del archivo que se desea abrir
* si lleva sólo un parámetro, es el nombre del archivo y en este caso lo abre con el programa que Windows tenga asociado.

```vbnet
System.Diagnostics.Process.Start(Rutavb) 'abre el archivo con el programa asociado de Windows
System.Diagnostics.Process.Start("Notepad.exe", Rutavb) 'abre el archivo en Bloc de Notas
System.Diagnostics.Process.Start("IExplore.exe", Rutavb) 'abre el archivo en Internet Explorer
```
