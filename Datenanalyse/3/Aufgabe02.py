import pandas as pd
# a)
states = pd.read_csv("bundeslaender.txt", sep=" ")
states = states[["land", "area", "female", "male"]]
states["population"] = states["male"] + states["female"]
states["density"] = ((states["population"] * 1000) / states["area"]).round()
states.to_csv("density.txt", sep=" ")
print(states)
# b)
states_more_females = states.loc[states["female"] > states["male"]]
print(states_more_females)
print("Anzahl der Bundesländer mit größerer weiblicher Bevölkerung " + str(states_more_females.shape[0]))
# c)
print(states.loc[((states["population"] * 1000) / states["area"]) > 1000])