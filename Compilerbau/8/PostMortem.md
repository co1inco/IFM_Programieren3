# Post mortem

Jede Person beschreibt in der ILIAS-Abgabe individuell(!) die Bearbeitung des jeweiligen Aufgabenblattes
zurückblickend mit ca. 200 bis 400 Wörtern. Gehen Sie dabei aussagekräftig und nachvollziehbar auf folgende Punkte ein: 
 (a) Zusammenfassung: Was wurde gemacht? 
 (b) Implementierungsdetails: Kurze Beschreibung besonders interessanter Aspekte der Umsetzung. 
 (c) Was war der schwierigste Teil bei der Bearbeitung? Wie haben Sie dieses Problem gelöst? 
 (d) Was haben Sie gelernt oder (besser) verstanden? 
 (e) Team: Mit wem haben Sie zusammengearbeitet? 
 (f) Link zum Repo mit der Lösung 



 
 * a: Deses Praktikum war als einführung in P++ gedacht. Wir sollten einen kleinen Lexer implementieren. Dafür sollte eine eingene version des std::shared_ptr implementiert werden, da hier die Speicherverwaltung und die Big 3 / 5 bzw. Copy und Move Semantik Anwendung finden. Zum Schluss sollten wir noch einen Ringpuffer implementieren, bei den der Speicher wiederverwendet wird.
 * b: Da ich bereits vorgeschädigt bin, konnte ich ich den SharedPtr als template Klasse anlegen. 
 * c: Ich hatte Probleme mit dem lexer, wodurch der nicht fertig geworden ist. Ich bin mir nicht sicher, ob ich Geister gejagt habe, oder aber tatsächlich mehrere Probleme hatte. Letztendlich hat sich aber herausgestellt, dass der Lexer eine Diskrepanz hatte. Die peak() Methode war bereits am EOF, der Token, der zurückgegeben wurde hat das aber nicht reflektiert, wodurch die tokenize() Methode nicht mitbekommen hat, dass der Lexer eigentlich schon fertig ist.
 * d: Mir waren copy und move vorher noch nicht so klar. Vor allem copy war mir in der Vergangenheit hauptsächlich ein begriff, weil CLion rum gemekert hat, dass ich doch bitte einen expliziten copy construktor anlegen soll.
 * e: -
 * f: https://github.com/co1inco/IFM_Programieren3/tree/master/Compilerbau/8
  

# Post mortem - Abschluss

# Post mortem

Jede Person beschreibt in der ILIAS-Abgabe individuell(!) die Bearbeitung des jeweiligen Aufgabenblattes
zurückblickend mit ca. 200 bis 400 Wörtern. Gehen Sie dabei aussagekräftig und nachvollziehbar auf folgende Punkte ein: 
 (a) Zusammenfassung: Was wurde gemacht? 
 (b) Implementierungsdetails: Kurze Beschreibung besonders interessanter Aspekte der Umsetzung. 
 (c) Was war der schwierigste Teil bei der Bearbeitung? Wie haben Sie dieses Problem gelöst? 
 (d) Was haben Sie gelernt oder (besser) verstanden? 
 (e) Team: Mit wem haben Sie zusammengearbeitet? 
 (f) Link zum Repo mit der Lösung 


 * a: Als Abschlussprojekt sollten wir einen Interpreter für ein subset von c++ erstellen. Da mit eine Implementation innerhalb der verbleibenden Zeit des Semesters möglich war wunden Dinge wie Pointer / Memory management, Templates und der Präprozessor heraus genommen. Die letztendlich implementierte Sprache soll aber dennoch gültiger C++ code sein, welcher sich mit einem normalen C++ Compiler übersetzen lässt.
 * b: Der Interpreter ist oin C# geschrieben und besteht aus drei Parsern. Dem Antlr Parser, AstParser und CppParser. Letzterer besteht wiederum aus 3 Stufen die nacheinander aufgerufen werden. Dadurch ist es möglich, Funktionen in beliebiger reihenfolge zu definieren ohne das Deklarationen nötig werden. Die letzte Parser-stufe gibt immer eine Funktion / Lambda zurück, welche die Interpretation des Ast Knoten ist. (Simple gesagt, sie führt den Ast Knoten aus). Außerdem ist interessant, wie ControlFlow statements wie return, break und continue gehandhabt werden. Und zwar haben Statements auch einen "Rückgabe Wert". Dies ist aber kein tatsächlicher Wert, sondern einer der erwähnten controlFlow werte (oder None für nichts). Dieser Rückgabewert wird dan zb. von einem Block statement überwacht, wen dieser seine unterstatements ausführt und handelt jeh nach Wert unterschiedlich. Da durch ist es nicht notwendig, auf Exceptions zurück zu greifen und auch das implementieren von break und continue war relativ trivial, obwohl sie nicht gefordert wahren
 * c: Das hinzufügen von Klassen war aufwändiger als ich erwartet hatte, obwohl die Codebasis schon dafür vorbereitet war.
 * d: Ich habe ein deutlich besseres Verständnis darüber entwickelt was im inneren eines Compilers vorgeht.
 * e: Muhammed Korkmaz, Aaron Schröder. (Mit den beiden habe ich erst nach Weihnachten eine Gruppe gebildet, nachdem ein anderes Gruppenmitglied abgesprungen war. Allerdings war meine Implementation zu dem zeitpunkt schon ziemlich Fortgeschritten, daher konnten die mässig gut einsteigen. Stadtessen habe ich einige Zeit damit verbracht, den Interpreter zu erklären)
 * f: https://github.com/co1inco/IFM_Programieren3-CPP_interpreter