import React from "react";
import { Home, Heart, LogIn } from "lucide-react";
import { useNavigate } from "react-router-dom";

const Navbar: React.FC = () => {
  const navigate = useNavigate();

  return (
    <nav className="w-full bg-white shadow-sm">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <span className="text-2xl font-bold text-orange-600">
              Flavor Finder
            </span>
          </div>
          <div className="flex items-center space-x-8">
            <button
              onClick={() => navigate("/")}
              className="flex items-center space-x-1 text-gray-800 hover:text-orange-600"
            >
              <Home size={20} />
              <span>Home</span>
            </button>
            <button
              onClick={() => navigate("/favorites")}
              className="flex items-center space-x-1 text-gray-800 hover:text-orange-600"
            >
              <Heart size={20} />
              <span>Favorites</span>
            </button>
            <button
              onClick={() => navigate("/login")}
              className="flex items-center space-x-1 px-4 py-2 rounded-md bg-orange-600 text-white hover:bg-orange-700"
            >
              <LogIn size={20} />
              <span>Login</span>
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
