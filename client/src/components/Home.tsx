import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  Coffee,
  UtensilsCrossed,
  Cookie,
  IceCream,
  Sandwich,
  Shuffle,
} from "lucide-react";

const mealTypes = [
  { name: "Any", icon: Shuffle },
  { name: "Breakfast", icon: Coffee },
  { name: "Lunch", icon: Sandwich },
  { name: "Dinner", icon: UtensilsCrossed },
  { name: "Snack", icon: Cookie },
  { name: "Dessert", icon: IceCream },
];

const cuisineTypes = [
  "Any",
  "African",
  "Asian",
  "American",
  "British",
  "Cajun",
  "Caribbean",
  "Chinese",
  "Eastern European",
  "European",
  "French",
  "German",
  "Greek",
  "Indian",
  "Irish",
  "Italian",
  "Japanese",
  "Jewish",
  "Korean",
  "Latin American",
  "Mediterranean",
  "Mexican",
  "Middle Eastern",
  "Nordic",
  "Southern",
  "Spanish",
  "Thai",
  "Vietnamese",
];

const Home: React.FC = () => {
  const [selectedMeal, setSelectedMeal] = useState("Any");
  const [selectedCuisine, setSelectedCuisine] = useState("Any");
  const navigate = useNavigate();

  const handleFindFlavor = () => {
    navigate(
      `/recipe?number=1&meal=${selectedMeal}&cuisine=${selectedCuisine}`
    );
  };

  return (
    <main className="max-w-4xl mx-auto px-4 py-8">
      <div className="text-center mb-8">
        <h1 className="text-4xl font-bold text-gray-900 mb-2">
          Random Recipe Generator
        </h1>
        <p className="text-gray-600">Discover your next culinary adventure</p>
      </div>
      <div className="grid grid-cols-2 md:grid-cols-6 gap-4 mb-8">
        {mealTypes.map(({ name, icon: Icon }) => (
          <button
            key={name}
            onClick={() => setSelectedMeal(name)}
            className={`p-4 rounded-lg ${
              selectedMeal === name
                ? "bg-orange-100 border-orange-500"
                : "bg-white border-gray-100"
            } shadow-sm hover:shadow-md transition-all duration-200 border-2 flex flex-col items-center justify-center gap-2 group`}
          >
            <Icon
              size={24}
              className={`${
                selectedMeal === name ? "text-orange-600" : "text-gray-600"
              } group-hover:scale-110 transition-transform duration-200`}
            />
            <span
              className={`${
                selectedMeal === name ? "text-orange-600" : "text-gray-800"
              } text-sm`}
            >
              {name}
            </span>
          </button>
        ))}
      </div>
      <div className="bg-white rounded-lg p-6 shadow-sm mb-8">
        <h2 className="text-xl font-semibold mb-4 text-gray-900">
          Select Cuisine Type
        </h2>
        <div className="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 lg:grid-cols-5 gap-3">
          {cuisineTypes.map((cuisine) => (
            <button
              key={cuisine}
              onClick={() => setSelectedCuisine(cuisine)}
              className={`p-2 rounded ${
                selectedCuisine === cuisine
                  ? "bg-orange-100 border-orange-500 text-orange-600"
                  : "bg-white border-gray-200 text-gray-800"
              } border transition-colors text-sm hover:border-orange-500 hover:bg-orange-50`}
            >
              {cuisine}
            </button>
          ))}
        </div>
      </div>
      <div className="text-center">
        <button
          onClick={handleFindFlavor}
          className="px-8 py-3 bg-orange-600 text-white rounded-md hover:bg-orange-700 transition-colors font-semibold shadow-sm hover:shadow-md"
        >
          Find Flavor
        </button>
      </div>
    </main>
  );
};

export default Home;
