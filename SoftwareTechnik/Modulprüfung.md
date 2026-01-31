
Um die Implementierung von Softwareprodukten zu vereinfachen, zu beschleunigen und im
Team zu koordinieren, ist es sinnvoll, ein Softwareprodukt vor der Implementierung gedanklich
zu  entwerfen.  Dazu  werden  die  technischen  und  nicht-technischen  Anforderungen  an  das
Softwareprodukt eindeutig, konsistent und so vollständig wie möglich beschrieben.
1  Aufgabenbeschreibung
Weiter  unten  finden  Sie  Informationen  und  Anforderungen  an  ein  Softwareprodukt  in
natürlicher Sprache. Diese Anforderungen wurden in einem Workshop mit Interessierten und
Beteiligten nach sorgfältiger Untersuchung notiert. Die Anforderungen stellen unter anderem
dar, welche Funktionalitäten das Softwareprodukt implementieren muss und welche Daten zu
speichern sind.Der Workshop verlief chaotisch, da viele Personen mit unterschiedlichen Interessen, Begriffen
und Ansichten teilgenommen haben. Daher können die Anforderungen ungeordnet, doppelt,
unvollständig, mehrdeutig, widersprüchlich oder sprachlich inkonsistent sein. Untersuchen Sie
daher die unten beschriebenen Informationen und Anforderungen an das Softwareprodukt und
erstellen Sie dafür eine technische Spezifikation in der Art und Weise, wie Sie es im Praktikum
gelernt haben.Benutzen  Sie  für  die  Beschreibung  der  Softwarearchitektur  das  4+1-Sichten-
Softwarearchitekturmodell.  Erstellen  Sie  für  die  einzelnen  Sichten  der  Softwarearchitektur
separate Kapitel und fügen Sie sämtliche zu modellierenden Aspekte in geeignete Kapitel des
Softwarearchitekturdokuments ein.Lesen und analysieren Sie die Anforderungen sorgfältig und überprüfen Sie die Anforderungen
auf  Widersprüche  und  Unvollständigkeiten.  Identifizieren  und  modellieren  Sie  im
Softwarearchitekturdokument folgende relevante Sachverhalte:
1.1  Funktionale und nicht-funktionale Anforderungen
Finden Sie einen aussagekräftigen Namen für das Softwareprodukt, der die Funktionalität
des Softwareprodukts ansprechend zum Ausdruck bringt.Identifizieren Sie und dokumentieren Sie sämtliche Aktoren (Akteure)Dokumentieren Sie die funktionalen Anforderungen in Form von User Stories mit Namen,
Akzeptanzkriterien und MoSCoW-Priorisierung in einer Tabelle mit sechs Spalten anhand
folgender beispielhaften Schablone:

| Name/ID | In meiner Rolle als...... | möchte ich... | ..., so dass... | Akzeptiert, wenn... | Priorität |
| ------- | ------------------------- | ------------- | --------------- | ------------------- | --------- |
| Lösung anzeigen | Benutzer | bei Fehleingabe die Lösung angezeigt bekommen | ich lernen kann | Lösung wird angezeigt | Muss |

 * Identifizieren und dokumentieren Sie funktionalen Gruppen (wie z.B. Profilverwaltung,...), in denen mehrere User Stories kategorisiert werden können. Fügen Sie für jede einzelne funktionale Gruppe ein separates Unterkapitel in das Dokument ein.
 * Modellieren Sie die Funktionalität des Softwareprodukts so umfangreich, sorgfältig und detailliert wie möglich und in voller Gänze.Beschreiben Sie nicht-funktionale Anforderungen und Qualitätsmerkmale anhand der ISO 25010.
 * Überprüfen Sie die (nicht-)funktionalen Anforderungen auf Unvollständigkeiten und ergänzen Sie fehlende Funktionalitäten, die Sie hilfreich und für den sinnvollen Ablauf der Software als notwendig erachten, aber nicht in den Anforderungen zu finden sind.
 * Stellen Sie die Begriffe der Fachdomäne des Softwareprodukts in einem Glossar dar

## 1.2  Graphische Benutzungsschnittstelle
Entwerfen Sie die graphische Benutzungsschnittstelle mit GUI-Mockups für sämtliche
Akteure.Achten Sie darauf, dass die GUI-Mockups zu den User Stories / funktionalen Gruppen
passen müssen.
Entwerfen Sie die Mockups sowohl für mobile Endgeräte als auch für Webbrowser, sofern
Ihr Team aus zwei oder drei Mitgliedern besteht.Stellen Sie unter den Dialogen/Screens dar (bzw. verlinken Sie im Dokument), welche
User Stories mit dem jeweiligen Dialog/Screen abgehandelt werden.Modellieren Sie die Navigation zwischen den Screens der GUI-Mockups als
Zustandsdiagramm und fügen Sie diese Diagramme jeweils als Überblick vor den
Mockups in das Dokument ein. Sollte sich die Navigation für unterschiedliche Akteure
unterscheiden, so modellieren Sie mehrere Zustandsdiagramme. Dies gilt auch für
unterschiedliche Navigationen bei Webbrowser und mobile Endgeräte.Legen Sie dar, welche Prinzipien Sie für das Design der graphischen
Benutzungsschnittstelle berücksichtigt haben.Finden Sie eine geeignete Inhaltsstruktur (z.B. geordnet nach Akteuren oder funktionalen
Gruppen) und fügen Sie dementsprechend Unterkapitel etc. in das Dokument ein.Kennzeichnen Sie die Dialoge/Screens mit Überschriften, so dass diese im
Inhaltsverzeichnis erscheinen.

## 1.3  Datenmodell
Entwerfen Sie für die beschriebenen Softwareprodukt-Anforderungen Modelle für die
persistent zu speichernden Daten, indem Sie das konzeptionelle/fachliche
Datenmodell/Domänenmodell mit einem Domänen-Klassendiagrammen in der UML-
Notation definieren. Modellieren Sie hierbei also Klassen, ungerichtete Beziehungen
zwischen diesen Klassen, Multiplizitäten der Beziehungen sowie die Beziehungsarten
Vererbung, Aggregation und Komposition. Ergänzen Sie fehlende Klassen und Attribute,
die Sie für die vollständige Abbildung der Domäne als sinnvoll erachten.Modellieren Sie die Zustandsübergänge einzelner Klassen mit einem UML-
Zustandsdiagramm.Überführen Sie das fachliche Datenmodell in ein logisches Datenmodell. Modellieren Sie
dazu im Detail sämtliche Attribute, unidirektionale Beziehungsrichtungen und löschen
Klassen, deren Daten für das Softwareprodukt irrelevant sind. Fügen Sie Klassen für
Bewegungsdaten hinzu, die im zeitlichen Durchlauf der Software erzeugt werden.Achten Sie bei der Erstellung der Datenmodelle darauf, dass die Datenmodelle zu den
Daten passen, die Sie in den GUI-Mockups darstellen.Erstellen Sie eine CRUD-Matrix und prüfen Sie, ob die funktionalen User Stories zu den
fachlichen Klassen passen und die Operationen vollständig sind.

## 1.4  Schnittstellen und Systemarchitektur
Beschreiben Sie die System-Schnittstellen (API) für Bestandteile/Komponenten des
verteilten Softwaresystems, insbesondere die REST-API des Servers.
Als Format für die API-Beschreibung kann die OpenAPI-Spezifikation verwendet werden.
Sie können die Beschreibung der API in das Dokument einfügen oder als separate Datei
zusammen mit der .pdf-Datei des Dokuments in einer zip-Datei abgeben.Stellen Sie für relevante User Stories die logisch-zeitlichen Abläufe von Aktoren und
Softwarebausteinen des Client-Server-Softwaresystems in UML-Sequenzdiagrammen dar.Modellieren Sie die Drei-Stufen-Systemarchitektur des Softwaresystems mit einem UML-
Verteilungsdiagramm, aus dem sämtliche beteiligten Hardware-Ressourcen (Clients,
Server etc.) zu erkennen sind.Identifizieren Sie mögliche Sicherheitsrisiken und Sicherheitsschwachstellen und
beschreiben Sie, wie Sie diese verhindern wollen. Führen Sie dazu eine
Bedrohungsmodellierung mittels STRIDE durch. Stellen Sie dabei nicht nur die
Bedrohungen dar, sondern zeigen Sie auch mögliche Schutzmaßnahmen auf, die die
Bedrohungen entschärfen.

# Automatic Zoom
Als Format für die API-Beschreibung kann die OpenAPI-Spezifikation verwendet werden.
Sie können die Beschreibung der API in das Dokument einfügen oder als separate Datei
zusammen mit der .pdf-Datei des Dokuments in einer zip-Datei abgeben.Stellen Sie für relevante User Stories die logisch-zeitlichen Abläufe von Aktoren und
Softwarebausteinen des Client-Server-Softwaresystems in UML-Sequenzdiagrammen dar.Modellieren Sie die Drei-Stufen-Systemarchitektur des Softwaresystems mit einem UML-
Verteilungsdiagramm, aus dem sämtliche beteiligten Hardware-Ressourcen (Clients,
Server etc.) zu erkennen sind.Identifizieren Sie mögliche Sicherheitsrisiken und Sicherheitsschwachstellen und
beschreiben Sie, wie Sie diese verhindern wollen. Führen Sie dazu eine
Bedrohungsmodellierung mittels STRIDE durch. Stellen Sie dabei nicht nur die
Bedrohungen dar, sondern zeigen Sie auch mögliche Schutzmaßnahmen auf, die die
Bedrohungen entschärfen.

# 2  Hinweise, Formales, Termine

## 2.1  Allgemein
Die Softwarespezifikation muss allein oder zu zweit oder zu dritt und in deutscher Sprache
angefertigt werden.Die Studenten, mit denen Sie zusammen die Modulprüfung ablegen, müssen nicht
dieselben sein, mit denen Sie die Praktikumsaufgabe beabeitet haben.Verteilen Sie die Aufgaben und Verantwortlichkeiten gleichmäßig auf die Teammitglieder
und dokumentieren Sie diese Verteilung in der technischen Spezifikation.Die Softwarespezifikation kann mit beliebigen Werkzeugen zur Textverarbeitung (Word,
Latex, etc.) geschrieben werden.Für die Modellierung von UML-Diagrammen, für das Erstellen von GUI-Mockups und
säntlichen weiteren Diagrammen können Sie eine beliebige Software nutzen. Fügen Sie die
erzeugten Diagramme und Mockups etc. in geeignete Kapitel Ihres Softwarespezifikations-
Dokument ein.
# 2.2  Inhalt
Finden Sie gemäß des 4+1-Sichten-Softwarearchitekturmodells eine geeignete
Inhaltsstruktur und fügen Sie die modellierten Sachverhalte in entsprechende Kapitel der
Softwarespezifikation ein. Stellen Sie diese Inhaltsstruktur als Inhaltsverzeichnis an den
Anfang des Dokuments dar.Achten Sie darauf, dass die Inhalte thematisch miteinander integriert sind und einen
logischen Zusammenhang darstellen. Dies gilt insbesondere dann, wenn Sie die
Projektarbeit zu zweit oder zu dritt durchführen und die Teilaufgaben untereinander
aufteilen und später integrieren müssen.Es existieren keine Anforderungen an die minimale oder maximale Seitenanzahl des
Dokuments.Stellen Sie eine Selbstständigkeitserklärung (s.u.) an den Anfang der Arbeit.Fügen Sie ein Titelblatt mit den Vor- und Nachnamen sowie der Matrikelnummer aller
beteiligten Studenten in das Dokument ein.Fügen Sie ggfs. Sachverhalte hinzu, die Sie für relevant halten.

## 2.3  Abgabe
Die Abgabe der Softwarespezifikation im Dateiformat ".pdf“ geschieht in ILIAS. Enthält
Ihre Abgabe mehrere Dateien, so benutzen Sie das zip-Dateiformat.Als Dateinamen (z.B. „Softwarespezifikation_Mueller_Meier_Schneider.pdf“) für das
Dokument verwenden Sie alle Nachnamen der Studenten, die an der Erstellung des
Dokuments beteiligt waren.Beachten Sie den Abgabetermin für die Softwarespezifikation im ILIAS. Später
eingehende Abgaben werden mit „mangelhaft“ bewertet.Sie können die Projektarbeit in der zweiten Klausurphase bearbeiten. Dazu müssen Sie
sich für die Modulprüfung für den zweiten Termin im LSF anmelden. Der Abgabetermin
und weitere Formalitäten für die zweite Klausurphase werden im Etherpad im ILIAS
bekanntgegeben.

## 2.4  Bewertungkritierien
Folgende Kriterien werden für die Bewertung sämtlicher erzeugten Artefakte benutzt:Logischer inhaltlicher ZusammenhangSorgfalt, Verständlichkeit, Vollständigkeit und Komplexität der modellierten
Funktionalität hinsichtlich der Softwareprodukt-AnforderungenTechnische Qualität und Korrektheit sämtlicher DiagrammeKreativität der Umsetzung der Softwareprodukt-AnforderungenTeamarbeit und gleichverteilte AufgabenverteilungUmfang der Softwarespezifikation in Relation zur TeamgrößeInterpunktion, Groß- und Kleinschreibung sowie Rechtschreibung
SelbstständigkeitserklärungHiermit versichere ich, dass ich die vorliegende Arbeit selbstständig und ohne die Benutzung
anderer als der angegebenen Hilfsmittel angefertigt habe. Alle Stellen - einschließlich Tabellen,
Karten,  Abbildungen  etc.  -,  die  wörtlich  oder  sinngemäß  aus  veröffentlichten  und  nicht
veröffentlichten Werken und Quellen (dazu zählen auch Internetquellen) entnommen wurden,
sind in jedem einzelnen Fall mit exakter Quellenangabe kenntlich gemacht worden.Zusätzlich  versichere  ich,  dass  ich  beim  Einsatz  von  generativen  IT-/KI-Werkzeugen  (z.B.
ChatGPT, BARD, Dall-E oder Stable Diffusion) diese Werkzeuge in einer Rubrik "Übersicht
verwendeter Hilfsmittel“ mit ihrem Produktnamen, der Zugriffsquelle (z. B. URL) und Angaben
zu  genutzten  Funktionen  der  Software  sowie  Nutzungsumfang  vollständig  angeführt  habe.
Wörtliche sowie paraphrasierende Übernahmen aus Ergebnissen dieser Werkzeuge habe ich
analog zu anderen Quellenangaben gekennzeichnet.Mir ist bekannt, dass es sich bei einem Plagiat um eine Täuschung handelt, die gemäß der
Prüfungsordnung sanktioniert werden wird.Ich  versichere,  dass  ich  die  vorliegende  Arbeit  oder  Teile  daraus  nicht  bereits  anderweitig
innerhalb und außerhalb der Hochschule als Prüfungsleistung eingereicht habe.Ort, Datum Name, Matrikelnummer

# 3  Anforderungen an das Softwareprodukt
Verwaltung von Veranstaltungen
Die  digitale  Planung,  Organisation,  Durchführung  und  Nachbereitung  von  privaten  und
öffentlichen Veranstaltungen bzw. Events in Gruppen wie beispielsweise Reisen (Skiurlaub etc.)
oder  Feste  (Grillfest  etc.)  ist  oft  unübersichtlich  und  anstrengend.  Über  verschiedene
Messenger-Dienste (WhatsApp etc.) werden Gruppen erstellt und über andere Dienste (Doodle
etc.) werden zusätzlich dazu Umfragen erstellt. Dies geschieht aus Bequemlichkeit, weil viele
Menschen  bereits  Messenger-Dienste  nutzen  und  dann  eine  Online-Gruppe  bilden,  in  der
relevante Informationen notiert werden. Wichtige Termine und weitere Daten werden schnell
vergessen oder müssen in langen Chats gesucht werden. Außerdem muss für eine Reise oft auch
Geld  eingesammelt  werden  und  es  fällt  bei  den  Einzahlungen  schwer,  den  Überblick  zu
behalten, wer bereits wieviel gezahlt hat. Es besteht daher der Wunsch, sämtliche Daten eines zu
planenden  Events  mit  einer  Software  zu  verwalten.  Da  bislang  keine  Software  mit  solchen
Features existiert, soll ein Softwareprodukt erstellt werden, so dass sich größere Gruppen für
den Urlaub oder für Feste besser organisieren können, indem die relevanten Daten ganzheitlich
erfasst  und  übersichtlich  dargestellt  werden.  Informationen  über  Orte,  Finanzen  oder
Absprachen können schnell gefunden werden, weil alle wichtigen Daten zentral an einem Ort
zur  Verfügung  stehen.  Aber  nicht  nur  Privatnutzer  wollen  Veranstaltungen  durchführen,
sondern auch kommerzielle Anbieter. Beide Nutzergruppen möchten ebenfalls die Dienste von
professionellen  Veranstaltungs-Dienstleistern  in  Anspruch  nehmen,  die  die  reibungslose
Durchführung von Veranstaltungen sicherstellen. Daher wird ein Softwareprodukt benötigt, mit
dem man sich registrieren und anmelden können muss. Zur Anmeldung benötigt man einen
Benutzernamen und ein Passwort. Das Passwort muss man zurücksetzen können. Hat man noch
keinen Account, muss man sich zunächst registrieren. Zum Registrieren wird ein Vorname,
Nachname, E-Mail-Adresse, Benutzername und ein Passwort, das zweimal eingetippt werden
muss, benötigt. Sämtliche Daten muss das Softwareprdukt sicher speichern. Insbesondere das
Passwort  muss  unleserlich  in  der  Datenbank  gespeichert  werden.  Dazu  soll  das  Passwort
„gehasht“  und  „gesalted“  werden.  Nach  der  Anmeldung  erhält  man  die  Übersicht  über  die
Gruppen, die man erstellt hat und denen man beigetreten ist und denen man beitreten kann.
Diese Liste ist sortiert und man kann die Liste nach Merkmalen sortieren. Man kann eine oder
mehrere  Gruppen  erstellen,  wobei  für  die  Erstellung  der  Name  der  Gruppe  und  eine
Beschreibung  benötigt  wird.  Man  kann  auch  bereits  erstellten  Gruppen  beitreten.  Selbst
erstellte  Gruppen  können  gelöscht  werden.  Gruppen  können  für  eine  gewisse  Zeit  erstellt
werden, danach werden sie automatisch archiviert oder gelöscht. Für eine Gruppe kann die
Liste der Mitglieder angezeigt werden. Zu einer Gruppe können andere Menschen eingeladen
werden. Eine solche Gruppe bekommt einen automatisch zufällig generierten Beitrittscode, der
für  andere  Mitglieder  benötigt  wird,  damit  diese  der  Gruppe  beitreten  können.  Mitglieder
können  die  Gruppe  eigenständig  verlassen.  Man  kann  angeben,  welche  Mindestanzahl  von
Teilnehmern vorhanden sein muss, damit das Event überhaupt stattfindet. Außerdem ist es
möglich, ein Event nur dann stattfinden zu lassen, wenn genügend Zahlungen eingegangen sind.
Jeder  potentielle  Teilnehmer  kann  dabei  eine  beliebige  Geldsumme  (jedoch  existiert  ein
Mindestbeitrag) einzahlen, auch denn, wenn die Mindestgeldsumme bereits erreicht ist. Es wird
den Teilnehmern angezeigt, wieviel Geld bereits eingegangen ist, was die Mindestgeldsumme ist
und wieviel Geld noch bis zum Erreichen benötigt wird. Diese Angaben sind auf der „Profilseite“
bzw.  „Homepage“  jedes  Events  ersichtlich.  Diese  Profilseite  kann  vom  Organisator  zum
Vermarkten  verwendet  werden,  da  die  URL  eindeutig  ist  und  nach  Erzeugung  nicht  mehr
geändert wird. Für diese URL wird ein QR-Code angezeigt, sodass die URL nicht mühsam
eingetippt  werden  muss.  Wählt  man  eine  Gruppe  aus  der  Gruppenliste  aus,  wird  der
Gruppenname und daneben den Beitrittscode sowie weitere relevante Informationen angezeigt.
Darunter  folgen  dann  sämtliche  Notizen.  Notizen  können  Ausgaben  (z.B.  „10  Euro  für
Grillkohle“), Umfragen (z.B. „Wo wollen wir den Urlaub verbringen?“), Termine (z.B. Zeit und
Ort einer Zugabfahrt) und Anmerkungen sein. Man soll sämtliche Notizen der Gruppe sehen
können. Notizen können erstellt und wieder gelöscht und auch geändert werden. Jeder Notiztyp
hat eine bestimmte Farbe, um die Übersicht zu behalten. Sortiert sind die Notizen nach dem
Erstellungsdatum. Die neueste Notiz steht ganz oben. Man hat so eine einfache und geordnete
Übersicht  über  wichtige  Dinge,  so  dass  die  Informationen  schnell  erkannt  werden  können.
Notizen  können  gefiltert  werden,  so  dass  man  sich  zum  Beispiel  nur  Ausgaben  oder  nur
Umfragen ansehen kann. Organisatoren können auch Umfragen einrichten, um vor oder nach
dem Event ein Feedback zur Meinungs- oder Zufriedenheitserfassung zu etablieren. Bei den
Umfragen sieht man eine Verteilung, wie viele Mitglieder für welche Antwort gestimmt haben.
Bei der Erstellung von Umfragen kann man dynamisch die Anzahl von Antwortmöglichkeiten
bestimmen. Jeder kann Umfragen erstellen und jeder kann an diesen Umfragen teilnehmen. Bei
den Umfragen kann festgelegt werden, ob mehrere Antworten ausgewählt werden können oder
nur  eine.  Bei  den  für  alle  sichtbaren  Ausgaben  sollen  am  Ende  die  gesamten  Ausgaben
übersichtlich dargestellt werden, um so sehen zu können, welche Person wieviel bezahlt hat. Die
Mitglieder  können  auch  Einzahlungen  vornehmen.  Ausgaben  werden  mit  Preis  und  einer
Bezeichnung erfasst. Neben einzelnen Ausgaben gibt es auch einen Kassensturz, bei dem man
eine  Übersicht  über  alle  Ausgaben  der  Gruppe  und  über  die  einzelnen  Personen  erhält.
Einzahlungen eines Mitglieds müssen gelöscht werden, wenn das Mitglied die Gruppe verlässt.
Der Organisator kann manuell eine Rückzahlung veranlassen. Bei der Registrierung kann man
die  bevorzugte  Datenkommunikation  (SMS,  E-Mail,  Whatsapp,  etc.)  definieren.  Wird  eine
Einzahlung  vorgenommen,  erhält  das  Mitglied  eine  Dankesnachricht  per  bevorzugtem
Kommunikationsmedium. Während man bei den Anmerkungen einen Freitext eingeben kann,
können bei den Terminen wichtige Daten eingetragen werden, wie z.B. Zugverbindungen oder
Abfahrtszeit oder Gleisnummer. Oder man hat zum Beispiel für die Reise bereits irgendeine
Attraktion gebucht und dort wird dann Datum, Zeit und eine Bemerkung dazu erfasst. Die
Durchführung  der  Events  kann  man  auch  dokumentieren,  indem  man  Kommentare  bzw.
Bewertungen  (z.B.  „Unvergessliches  Erlebnis“)  und  Multimedia-Dateien  (z.B.  Fotos  oder
Videos) hochladen kann. Nachdem ein Event stattfinden kann, können Zeitpläne und noch
