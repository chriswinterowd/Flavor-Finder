import { useNavigate } from "react-router-dom";
import { useQuery } from "@tanstack/react-query";
import axios from "axios";

interface FavoriteRecipe {
  id: number;
  title: string;
  image: string;
  cuisines: string[];
  dishTypes: string[];
}

export function Favorites() {
  const navigate = useNavigate();

  const {
    data: favorites,
    isLoading,
    isError,
  } = useQuery<FavoriteRecipe[]>({
    queryKey: ["favorites"],
    queryFn: async () => {
      const response = await axios.get("http://localhost:5000/api/recipe/favorites", {
        withCredentials: true,
      });
      return response.data;
    },
  });

  if (isLoading) {
    return <div className="text-center text-gray-600">Loading your favorites...</div>;
  }

  if (isError) {
    return <div className="text-center text-red-600">Failed to load favorites.</div>;
  }

  if (!favorites || favorites.length === 0) {
    return <div className="text-center text-gray-600">You have no favorite recipes yet.</div>;
  }

  return (
    <div className="max-w-5xl mx-auto px-4 py-8">
      <h1 className="text-3xl font-bold text-gray-900 mb-6">Your Favorite Recipes</h1>
      <div className="space-y-4">
        {favorites.map((recipe) => (
          <div
            key={recipe.id}
            className="flex items-center bg-white rounded-lg shadow-md p-4 hover:shadow-lg transition-shadow"
          >
            <img
              src={recipe.image}
              alt={recipe.title}
              className="w-20 h-20 object-cover rounded-md mr-4"
            />
            <div className="flex-1">
              <h2 className="text-lg font-semibold text-gray-800">{recipe.title}</h2>
              <div className="flex flex-wrap gap-2 mt-2">
                {recipe.cuisines.map((cuisine) => (
                  <span
                    key={cuisine}
                    className="px-2 py-1 bg-orange-100 text-orange-700 rounded-full text-xs"
                  >
                    {cuisine}
                  </span>
                ))}
                {recipe.dishTypes.map((type) => (
                  <span
                    key={type}
                    className="px-2 py-1 bg-gray-100 text-gray-700 rounded-full text-xs"
                  >
                    {type}
                  </span>
                ))}
              </div>
            </div>
            <button
              className="ml-4 px-4 py-2 bg-orange-600 text-white rounded-md hover:bg-orange-700 transition-colors"
              onClick={() => navigate(`/recipe/${recipe.id}`)}
            >
              View
            </button>
          </div>
        ))}
      </div>
    </div>
  );
}
