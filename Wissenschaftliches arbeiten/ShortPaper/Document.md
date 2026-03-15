


## Clock
Unter der Clock versteht man den Impulsgeber eines Prozessors. Mit jedem Impuls der Clock führt der Prozessor einen Schritt aus. Dadurch gibt die Clock auch die Geschwindigkeit des Prozessors aus. Jeh schneller die Clock, desto schneller der Prozessor. Man kann die Geschwindigkeit der Clock allerdings nicht unbegrenzt erhöhen, da die restlichen Komponenten des Prozessors nur begrenzt schnell arbeiten können. Man muss daher die schellst-mögliche Frequenz finden, bei der die Restlichen Komponenten weiterhin zuverlässig arbeiten. Außerdem steigt mit der erhöhten Rechengeschwindigkeit auch der Strombedarf des Prozessors. Eine geringere Frequenz kann also Vorteilhaft sein, wenn man Energie Sparen möchte. Zum Beispiel weil die maximale mögliche Energieaufnahme begrenzt ist. 
Als Clock signal kann Grundsätzlich jedes Rechtecksignal verwendet werden. üblicherweise verwendet man jedoch einen Quarz, wodurch die Impulse eine sehr genaue Frequenz haben. Der Prozessor kann anhand der Zyklen die genaue Vergangene zeit bestimmen. Ein Quarz wird aber nicht zwingen gefordert. Häufig besitzen Mikroprozessoren eine eingebaute RC Schaltung, die zur Erzeugung des Clock Impulses verwendet werden kann. Diese ist jedoch nicht so genau wie ein Quarz. (Sie kann sich zB. bei Temperatur Änderungen verändern). Theoretisch ist es sogar möglich, einen Taster zu verwenden, wodurch eine Art Schritt-Betrieb erreicht wird. Das ist aber lediglich wür experimentelle / forschende Zwecke sinnvoll. Zu dem haben moderne Prozessoren eine Mindestgeschwindigkeit und Arbeiten nicht mehr richtig, wenn die Clock zu langsam ist.

## Register
Ein Register ist die schellst Speicherart in einem Prozessor und halten die Daten, mit denen der Prozessor im augenblick arbeitet.

## Programmzähler
Der Programmzähler enthält die Speicheradresse der nächsten, aufzuführenden Instruktion dar. Am Anfang eines Instruktionszyklus wird die Instruktion, an der, von dem Programmzähler vorgegebene Speicheradresse in das Steuerwerk geladen. Anschließend wird der Programmzähler um 1 erhöht, so das er auf den nächsten Wert im Speicher zeigt. Manche Instruktionen sind größer als eine Speichereinheit. In dem fall wird der Programmzähler mehrfach innerhalb eines Zyklus inkrementiert. 
Sprung Instruktionen (JMP, RET, BNE, etc.) Funktionieren, in dem die Ziel Addresses der Instruktion in den Programmzähler geladen wird. Im nächsten Schritt wird also nicht mehr die "nächste" Instruktion abgerufen, sondern die, an der angegebenen Zieladresse.
*Note: Bei einer return Instruktion wird die Zieladresse vom Stack gepoppt.*

## Speicher
Als Speicher versteht man den gesamten Speicher eines Prozessors. Dies umfasst so wohl den Programmspeicher (ROM), der die Ausführbaren Instruktionen enthält als auch den Arbeitsspeicher (RAM), den der Prozessor zum Speichern temporärer Daten enthält und meist flüchtig ist. Der Speicher wird über die Speicheradressen adressiert. 
Bei der Verarbeitung von Speicheradressen kommt häufig Schaltlogik zum einsatz. 
Beispiel: Angenommen ein Prozessor hat einen Address Größe von 8bit, dann könnte der Prozessor insgesamt 256 Werte adressieren. Man kan nun einen RAM und einen ROM chip so an den Prozessor anschließen, das der RAM chip aktiv ist, wenn das MSB der Addresses HIGH ist. Wenn das bit LOW ist wird stadtessen der ROM chip aktiviert. Die ersten 128 Werte kommen dann aus dem ROM Chip, die Werte an den Adressen 128-255 aus dem RAM Chip. Der Prozessor selbst bekommt davon aber nichts mit. 
Der vorhandene Speicher hängt von dem Prozessor ab. Heutige Mikrocontroller haben üblicherweise einen integrierten RAM und Flash Speicher. Letzterer dient als Programm speicher. Mikroprozessoren (zb. x86) haben stattdessen lediglich einen Arbeitsspeicher. Das Programm, dass ausgeführt werden soll wird vor dem Ausführen aus einem externen Speicher in den RAM geladen.

### Stack
Der Stack ist eine definierte Region im RAM. Dessen funktionsweise kann man sich wie einen Papierstapel vorstellen. Neue Daten werden immer nur oben auf den Stapel abgelegt und auch immer nur von oben von dem Stapel entnommen.
...
