import React from "react";
import { Home, Heart, LogIn, LogOut } from "lucide-react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

interface NavbarProps {
  onOpenAuthModal: () => void;
}

export function Navbar({ onOpenAuthModal }: NavbarProps) {
  const navigate = useNavigate();
  const { isAuthenticated, logout } = useAuth();

  return (
    <nav className="w-full bg-white shadow-sm">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16">
          <div className="flex items-center">
            <span className="text-2xl font-bold text-orange-600">Flavor Finder</span>
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
            {isAuthenticated ? (
              <button
                onClick={logout}
                className="flex items-center space-x-1 px-4 py-2 rounded-md bg-red-600 text-white hover:bg-red-700"
              >
                <LogOut size={20} />
                <span>Logout</span>
              </button>
            ) : (
              <button
                onClick={onOpenAuthModal}
                className="flex items-center space-x-1 px-4 py-2 rounded-md bg-orange-600 text-white hover:bg-orange-700"
              >
                <LogIn size={20} />
                <span>Login</span>
              </button>
            )}
          </div>
        </div>
      </div>
    </nav>
  );
}
