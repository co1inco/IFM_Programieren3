import pandas as pd
import matplotlib.pyplot as plt
import seaborn as sns
from sklearn.preprocessing import StandardScaler

df = pd.read_csv("herford_weather.csv", parse_dates=['time']).set_index('time')

# a)
cols = [
    'temperature_2m (°C)', 
    'relativehumidity_2m (%)', 
    'dewpoint_2m (°C)',
    'apparent_temperature (°C)', 
    'pressure_msl (hPa)', 
    'surface_pressure (hPa)', 
    'precipitation (mm)', 
    'rain (mm)', 
    'snowfall (cm)',
    'weathercode (wmo code)', 
    'cloudcover (%)', 
    'cloudcover_low (%)', 
    'cloudcover_mid (%)', 
    'cloudcover_high (%)', 
    'shortwave_radiation (W/m²)', 
    'direct_radiation (W/m²)', 
    'diffuse_radiation (W/m²)', 
    'direct_normal_irradiance (W/m²)', 
    'windspeed_10m (km/h)',
    'windspeed_100m (km/h)', 
    'winddirection_10m (°)', 
    'winddirection_100m (°)', 
    'windgusts_10m (km/h)', 
    'et0_fao_evapotranspiration (mm)', 
    'vapor_pressure_deficit (kPa)', 
    'soil_temperature_0_to_7cm (°C)', 
    'soil_temperature_7_to_28cm (°C)',
    'soil_temperature_28_to_100cm (°C)', 
    'soil_temperature_100_to_255cm (°C)', 
    'soil_moisture_0_to_7cm (m³/m³)',
    'soil_moisture_7_to_28cm (m³/m³)', 
    'soil_moisture_28_to_100cm (m³/m³)', 
    'soil_moisture_100_to_255cm (m³/m³)'
]
data = df[cols].dropna()
# Visualisierung
corr_matrix = data.corr()

# abs -> both pos and neg correlation should work
target_corr = corr_matrix['dewpoint_2m (°C)'].abs().sort_values(ascending=False)
print(target_corr[:10]) 

top_features = target_corr.index[1:11]  # [1: ] to remove self

plt.figure(figsize=(10, 6))
sns.barplot(x=target_corr[top_features], y=top_features)
plt.show()

# b)
cols2 = [
    'temperature_2m (°C)', 
    'dewpoint_2m (°C)',
    'apparent_temperature (°C)', 
    'vapor_pressure_deficit (kPa)', 
    'soil_temperature_0_to_7cm (°C)', 
    'soil_temperature_7_to_28cm (°C)',
    'soil_temperature_28_to_100cm (°C)', 
    'soil_temperature_100_to_255cm (°C)', 
    'soil_moisture_0_to_7cm (m³/m³)',
    'soil_moisture_7_to_28cm (m³/m³)', 
    'soil_moisture_28_to_100cm (m³/m³)', 
    'soil_moisture_100_to_255cm (m³/m³)'
]
data2 = df[cols2].dropna()
sc = StandardScaler()
df[cols2] = sc.fit_transform(df[cols2])