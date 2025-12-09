# Post mortem

Jede Person beschreibt in der ILIAS-Abgabe individuell(!) die Bearbeitung des jeweiligen Aufgabenblattes
zurückblickend mit ca. 200 bis 400 Wörtern. Gehen Sie dabei aussagekräftig und nachvollziehbar auf folgende Punkte ein: 
 (a) Zusammenfassung: Was wurde gemacht? 
 (b) Implementierungsdetails: Kurze Beschreibung besonders interessanter Aspekte der Umsetzung. 
 (c) Was war der schwierigste Teil bei der Bearbeitung? Wie haben Sie dieses Problem gelöst? 
 (d) Was haben Sie gelernt oder (besser) verstanden? 
 (e) Team: Mit wem haben Sie zusammengearbeitet? 
 (f) Link zum Repo mit der Lösung 



 
 * a: In diesem Praktikum sollten wir einen Lisp Interpreter implementieren. Als Basis dafür habe ich den Parser verwendet, den ich für Blatt 4 selber implementiert und nach dem Praktikum noch etwas überarbeitet hatte. Mein parser ähnelt der "Grammatik A" auf dem Aufgabenblatt. Der Interpreter besteht hauptsächlich aus einer eval Funktion, die wiederholt von der mainloop ausgeführt wird.
 * b: Ich habe für diese Aufgabe F# benutzt und dank der match Operation von F# ist die eval Funktion schön Kompakt. Ein Literal wird direkt zurück gegeben. Ein Atom wird durch das aktuelle Environment Aufgelöst und eine List wird entsprechend seines Inhalt unterschiedlich behandelt. Das alles kann in einem match statement Aufgelöst werden. Außerdem ist das "Environment" interessant. In meiner Ursprünglichen implementation war das Environment ein Dictionary welches "ListValClass" enthielt. Hier hatte ich die OOP Fähigkeiten von F# genutzt um einen Reference Typen im Dictionary zu speichern. Für jeden scope wurde das parent Dictionary kopiert und so lange ein vert nicht neu gebunden wurde, zeigte der Inhalt eines dict Items auf die Ursprüngliche Version. Ich bin mir nicht sicher, warum ich das damals so gelöst hatte. Ich habe das aber für dieses Projekt überarbeitet. Nun erhält ein neuer scope lediglich eine Referenz zu dem paren scope und Fragt diesen nach einer Variable, wen diese nicht im eigenen Scope (Dictionary) zu finden ist. Hier Verwende ich sogar wieder die OOP Fähigkeiten, wobei das Wahrscheinlich nicht mal notwendig ist
 * c: Ich musste arg aufpassen, dass ich den Interpreter, denn ich schon vorher geschrieben hatte nicht 1 zu 1 kopiere.
 * d: 
 * e: -
 * f: https://github.com/co1inco/IFM_Programieren3/tree/master/Compilerbau/7

