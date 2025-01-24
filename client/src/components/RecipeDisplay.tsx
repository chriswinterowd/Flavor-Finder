import { useEffect, useState } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { Heart, Clock, Users, UtensilsCrossed, ChefHat, Soup } from "lucide-react";

interface Ingredient {
  id: number;
  name: string;
  amount: number;
  unit: string;
  image: string;
}

interface Instruction {
  number: number;
  step: string;
}

interface RecipeInstructions {
  steps: Instruction[];
}

interface Recipe {
  id: number;
  title: string;
  readyInMinutes: number;
  servings: number;
  image: string;
  summary: string;
  cuisines: string[];
  dishTypes: string[];
  extendedIngredients: Ingredient[];
  analyzedInstructions: RecipeInstructions[];
}

export function RecipeDisplay() {
  const [recipe, setRecipe] = useState<Recipe | null>(null);
  const location = useLocation();

  const queryParams = new URLSearchParams(location.search);
  const meal = queryParams.get("meal");
  const cuisine = queryParams.get("cuisine");

  const navigate = useNavigate();
  const handleFindNewFlavor = () => {
    navigate("/");
  };

  useEffect(() => {
    const fetchRecipe = async () => {
      try {
        const response = await fetch(
          `http://localhost:5000/api/recipe/random?number=1&meal=${
            meal === "any" ? "" : meal
          }&cuisine=${cuisine === "any" ? "" : cuisine}`
        );

        if (!response.ok) {
          if (response.status === 404) {
            console.error("No recipes found (404 Not Found).");
            setRecipe(null);
          } else {
            console.error(`Error: HTTP ${response.status}`);
            setRecipe(null);
          }
          return;
        }

        const data = await response.json();

        console.log(data);
        setRecipe(data);
      } catch (error) {
        console.error("Failed to fetch recipe:", error);
        setRecipe(null);
      }
    };

    fetchRecipe();
  }, [meal, cuisine]);

  if (!recipe) return <div className="text-center text-gray-600">Loading...</div>;

  return (
    <div className="max-w-4xl mx-auto px-4 py-8">
      <div className="mb-6">
        <h1 className="text-3xl font-bold text-gray-900 mb-3">{recipe.title}</h1>
        <div className="flex flex-wrap gap-2">
          {recipe.cuisines?.map((cuisine) => (
            <span
              key={cuisine}
              className="px-3 py-1 bg-orange-100 text-orange-700 rounded-full text-sm"
            >
              {cuisine}
            </span>
          ))}
          {recipe.dishTypes?.map((type) => (
            <span
              key={type}
              className="px-3 py-1 bg-orange-100 text-orange-700 rounded-full text-sm"
            >
              {type}
            </span>
          ))}
        </div>
      </div>
      <div className="flex flex-wrap gap-6 mb-6">
        <div className="flex items-center gap-2 text-gray-600">
          <Clock size={20} />
          <span>{`${recipe.readyInMinutes} minutes`}</span>
        </div>
        <div className="flex items-center gap-2 text-gray-600">
          <Users size={20} />
          <span>{`${recipe.servings} servings`}</span>
        </div>
      </div>
      <div className="aspect-video w-full bg-gray-100 rounded-lg overflow-hidden mb-8">
        <img src={recipe.image} alt={recipe.title} className="w-full h-full object-cover" />
      </div>
      <div className="bg-white rounded-lg p-6 shadow-sm mb-8">
        <p className="text-gray-700">{recipe.summary.replace(/<\/?[^>]+(>|$)/g, "")}</p>
      </div>
      <div className="bg-white rounded-lg p-6 shadow-sm mb-8">
        <h2 className="text-xl font-semibold mb-4 flex items-center gap-2">
          <Soup size={24} className="text-orange-600" />
          Ingredients
        </h2>
        <div className="grid grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-3">
          {recipe.extendedIngredients?.map((ingredient) => (
            <div
              key={ingredient.id}
              className="flex items-center gap-2 bg-orange-50/50 rounded p-2"
            >
              {ingredient.image && (
                <img
                  src={`https://spoonacular.com/cdn/ingredients_100x100/${ingredient.image}`}
                  alt={ingredient.name}
                  className="w-8 h-8 object-cover rounded"
                />
              )}
              <span className="text-sm text-gray-700">
                {ingredient.amount} {ingredient.unit} {ingredient.name}
              </span>
            </div>
          ))}
        </div>
      </div>
      <div className="bg-white rounded-lg p-6 shadow-sm mb-8">
        <h2 className="text-xl font-semibold mb-4 flex items-center gap-2">
          <UtensilsCrossed size={24} className="text-orange-600" />
          Instructions
        </h2>
        <ol className="space-y-6">
          {recipe.analyzedInstructions?.[0]?.steps?.map((instruction) => (
            <li key={instruction.number} className="flex gap-4">
              <span className="font-bold text-orange-600 text-lg">{instruction.number}.</span>
              <p className="text-gray-700">{instruction.step}</p>
            </li>
          ))}
        </ol>
      </div>
      <div className="flex justify-center gap-4 mt-8">
        <button
          className="px-6 py-3 bg-orange-600 text-white rounded-md hover:bg-orange-700 transition-colors font-semibold flex items-center gap-2"
          onClick={handleFindNewFlavor}
        >
          <ChefHat size={20} />
          Find New Flavor
        </button>
        <button className="px-6 py-3 border-2 border-orange-600 text-orange-600 rounded-md hover:bg-orange-50 transition-colors font-semibold flex items-center gap-2">
          <Heart size={20} />
          Favorite
        </button>
      </div>
    </div>
  );
}
