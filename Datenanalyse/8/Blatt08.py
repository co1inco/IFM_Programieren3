import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
import numpy as np
import sklearn
from sklearn import preprocessing
from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import train_test_split
from keras.models import Sequential
from keras.layers import Dense, Activation
from keras.callbacks import EarlyStopping, ModelCheckpoint
from keras.models import load_model
from keras.regularizers import l2

# ---------------------------------- Aufgabe 01 ----------------------------------
# Daten importieren
df = pd.read_csv("rawdata_luftqualitaet.csv")
print(df.head())

# Standardskalieren
sc = StandardScaler()

cols = ['humidity_inside', 'temperature_inside', 'co2_inside', 'temperature_heater', 'temperature_wall_inside']
df[cols] = sc.fit_transform(df[cols])

x_train, x_test, y_train, y_test = train_test_split(df[cols], df['state_air_quality'], test_size=0.2, random_state=42)

print(df.head())
print(x_train.shape, x_test.shape, y_train.shape, y_test.shape)

# a) Model erstellen
model = Sequential(name = "sequential_3")
model.add(Dense(units = 60, activation = 'relu', input_shape=(5, ), name = "dense_9"))
model.add(Dense(units = 60, activation = 'relu', name = "dense_10"))
model.add(Dense(units = 3, activation = 'softmax', name = "dense_11"))
model.compile(loss = 'sparse_categorical_crossentropy', optimizer = 'adam', metrics = ['accuracy'])
print(model.summary())

# b) Model trainieren
history = model.fit(x_train, y_train, epochs = 200, batch_size = 32, validation_data = (x_test, y_test), verbose = False)
# loss, acc = model.evaluate(x_test, y_test)
# print('loss: {:.5f}, accuracy: {:.5f}'.format(loss, acc))
train_loss = history.history['loss']
test_loss = history.history['val_loss']

# Grafik
epochs = range(1, len(train_loss) + 1)

fig, ax = plt.subplots()
ax.plot(epochs, train_loss, label = 'train loss')
ax.plot(epochs, test_loss, label = 'test loss')
ax.set_xlabel('epochs')
ax.set_ylabel('loss (sparse cross entropy)')
plt.legend()
plt.show()

# ---------------------------------- Aufgabe 02 ----------------------------------

# a) Model erstellen
model = Sequential(name = "sequential_3")
model.add(Dense(units = 60, activation = 'relu', input_shape=(5, ), name = "dense_9"))
model.add(Dense(units = 60, activation = 'relu', name = "dense_10"))
model.add(Dense(units = 3, activation = 'softmax', name = "dense_11"))
model.compile(loss = 'sparse_categorical_crossentropy', optimizer = 'adam', metrics = ['accuracy'])

# Callbacks
stopping = EarlyStopping(monitor = 'val_loss', patience = 5)
checkpoint = ModelCheckpoint(filepath = 'my_model.keras', monitor = 'val_loss', save_best_only = True)

# b) Model trainieren
history = model.fit(x_train, y_train, epochs = 200, batch_size = 32, validation_data = (x_test, y_test), callbacks = [stopping, checkpoint], verbose = False)
# saved_model = load_model('my_model.keras')
train_loss = history.history['loss']
test_loss = history.history['val_loss']

stopped_epoch = len(train_loss)
print('Epochen bis EarlyStopping: ' + str(stopped_epoch))

# Grafik
epochs = range(1, len(train_loss) + 1)

fig, ax = plt.subplots()
ax.plot(epochs, train_loss, label = 'train loss')
ax.plot(epochs, test_loss, label = 'test loss')
ax.set_xlabel('epochs')
ax.set_ylabel('loss (sparse cross entropy)')
plt.legend()
plt.show()

# ---------------------------------- Aufgabe 03 ----------------------------------

reg = l2(l2 = .001)

# a) Model erstellen
model = Sequential(name = "sequential_3")
model.add(Dense(units = 60, activation = 'relu', input_shape=(5, ), kernel_regularizer = reg, name = "dense_9"))
model.add(Dense(units = 60, activation = 'relu', kernel_regularizer = reg, name = "dense_10"))
model.add(Dense(units = 3, activation = 'softmax', kernel_regularizer = reg, name = "dense_11"))
model.compile(loss = 'sparse_categorical_crossentropy', optimizer = 'adam', metrics = ['accuracy'])
print(model.summary())

# b) Model trainieren
history = model.fit(x_train, y_train, epochs = 200, batch_size = 32, validation_data = (x_test, y_test), verbose = False)
train_loss = history.history['loss']
test_loss = history.history['val_loss']

# Grafik
epochs = range(1, len(train_loss) + 1)

fig, ax = plt.subplots()
ax.plot(epochs, train_loss, label = 'train loss')
ax.plot(epochs, test_loss, label = 'test loss')
ax.set_xlabel('epochs')
ax.set_ylabel('loss (sparse cross entropy)')
plt.legend()
plt.show()
