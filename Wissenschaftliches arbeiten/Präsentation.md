---
marp: true
theme: uncover
class: invert
style: |
    h2 {
        font-size: inherit;
        font-weight: 5;
    }
    h3 {
        font-size: calc(inherit - 2px);
        font-weight: inherit;
    }
    p {
        font-weight: 400
    }
---

## Test
# Anders Hejlsberg
asdasd

---

# Anders Hejlsberg

![](500px-Anders_Hejlsberg.jpg)

<!--
So sieht er aus
-->

---

## Warum?
 * Turbo Pascal
 * Delphi
 * .NET / C#
 * TypeScript

<!--
Warum beschäftigen wir uns mit ihm?
-->

---

# Verlauf

 * Geburt
 * Leben
 * ~~Tod~~

<!--
Spoiler: irgendwann stirbt er
-->

---

## Technische Daten

|            |     |
| :--------- | --- |
| Name       | Anders Hejlsberg
| Geburtstag | 2.12.1960 (64 Jahre)
| Ort        | Copenhagen, Denmark
| Studium    | Engineering @ Technische Universität Dänemark

<!--
https://web.archive.org/web/20090427201423/http://www.microsoft.com/presspass/exec/techfellow/Hejlsberg/default.mspx [03.11.2025 19:10]
-->

---

## 1980 - 1982: Pascal

 * Turbo Pascal
 * Borland
 * Erste IDE

<!--
 * Pascal compiler.
 * Lizenziert von Borland
 * Editor und Debugger hinzugefügt. War eine der ersten IDEs

-->

---

## 1991: Delphi
 * Windows 
 * Delphi
 * Chefentwickler

![bg right width: 60%](Delphi-1929843066.png)

<!--

 * Windows veröffentlicht
 * Delphi mit support für Windows GUIs
 * Chefentwickler für ersten 3 Versionen
 * Noch heute bei: embarcadero, Kosten: 1.682€

-->

---

```delphi
program ArrayLoop;
{$APPTYPE CONSOLE}  
const a : array[1..3] of real = ( 1.1, 2.2, 3.3 );
var f : real;
begin
  for f in a do
    WriteLn( f );    
end.
```

---

## 1996: Angebot

 * Microsoft: .5 Mio
 * Borland: Kontenangebot
 * Microsoft: verdoppelt
 * Wechsel Oktober 1996
  
<!--
Borland verklagt Microsoft wegen Abwerbetaktik.
Borland gewinnt, Hejlsberg hat aber bereits gewechselt.
Hejlsberg gibt an das er sich nicht mehr für Unverzichtbar hält und neue Herausforderungen gesucht hat.
Bil Gates hat ihn Persönlch eingeladen

https://web.archive.org/web/20211206140132/https://titanwolf.org/Network/Articles/Article?AID=65cd7255-831c-4237-becc-bd864605cd35

-->

---

## 1996+: Visual J++

 * Microsofts Java Implementierung
 * Unzureichende JVM Kompatibilität
 * Klage von Sun

<!--
Alles wird Java. Java überall.
J++: Implementierung von Java und Microsofts JVM.
Später J# -> Java für .NET Framework
Proprietär Implementierung für windows.
Implementierung nicht vollständig Kompatible mit JVM.
Microsoft > Proprietär, Sun > Plattformunabhängig.
MS verliert Rechtsachtreit
MSJVM auf (veralteter) Java version 1.1.4 gefreezed.
Aus für J++

-->

---

## 2000: .NET Framework

![bg left width: 70%](dotnet-logo.png)

 * C++, VisualBasic, J++ inkompatibel
 * Gemeinsame basis
  
<!--
Die primären Programmiersprachen auf Windows: C++, VisualBasic, J++ sind grundsätzlich inkompatibel.
.NET als gemeinsame basis.

-->

---

## 2000: C#

 * Leitender Designer

 # TODO

<!--
Ohne J# wird eine neue Sprache für das .NET framework benötigt.
Daraufhin entwickelt Hejlsberg C#
-->

---

<style>
    .container {
        display: flex;
    }
    .col {
        flex: 1;
    }
</style>

# 2001

<div class="container">

<div>
<p>Dr. Dobb's Excellence in Programming Award</p>

<i>
"Über arbeiten an TurboPascal bis C#, hat Anders Hejlsberg signifikante Beiträge zu der Kust und der Wissenschaft des Programmierens getätigt."[1]
</i>
</div>

<div class="col">
<img src="0105af1.gif"/>
</div>

</div>

<!--

https://web.archive.org/web/20140708060629/https://www.drdobbs.com/windows/dr-dobbs-excellence-in-programming-award/184404602 [03.11.2025 23:15]

-->

---

![bg left width 80%](c_sharp.png)

## C#
 * 2005: Generics, partielle Typen, ...
 * 2008: Extension members, LINQ, ...
 * 2012: async, await, ...


<!--

https://www.webdevtutor.net/blog/c-sharp-history [05.11.2025 00:20]

-->

---

```C#
public static class MyClass<T>
{
    public static Type MyType() { return typeof(T); }

    // LINQ / extension member Beispiel
    public static IEnumerable<T> MyFunc(this IEnumerable<T> collection) {
        return collection
            .Where(x => ...)
            .Select(x => ...)
            .OrderBy(x => ...);
    }

    // async / await Beispiel
    public static async Task<string> MyAsyncFunc(HttpClient client) {
        var result = await client.GetAsync("example.com");
        if (!result.IsSuccessStatusCode) { ... }
        return await result.Content.ReadAsStringAsync();
    }
}

```


---

### Buch: "The C# Programming Language"
![](41ScuFnIZdL._SY425_.jpg)

<!--
"The C# Programming Language" beispiel von 2006
https://www.amazon.de/C-Programming-Language-Anders-Hejlsberg/dp/0321334434 [05.11.2025 00:17]
-->

---

## ab 2010

 * Umstellung auf Roslyn Compiler 
 * Open Source
 * Langeweile
 * #Script
 

<!--
https://www.heise.de/hintergrund/Neues-zu-Roslyn-und-C-2292919.html [05.11.2025 00:40]

2012 ist der C# compiler auf den Roslyn compiler umgestellt worden (C# basierend).

Öffentlich Verfügbar auf BUILD 2014
Hejlsberg veröffentlichte das repo live.
Erster release Visual Studio 2015

Während dieser Zeit hat das Design team nicht viel zu tun.
Was machen Langauge Designer wen sie nichts zu tun haben?

Sprache im web nicht Java sonder JavaScript
JavaSCript Projekte wachsen, JavaScript Skaliert aber nicht.
Webentwickler habe nach einem C# -> Javascript compiler gefragt

Tools für erwachsene. eg: Refactoring

Hejlsberg -> C# nicht geeignet

-->

---

# Typescript

---

## Person

 - Neutral
 - Zuhörer

<!--
Hejlsberg ist bekannt dafür sich alle Standpunkte neutral anzuhören.
EG: "checked Exceptions"
-->