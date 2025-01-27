import { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { AuthProvider } from "./context/AuthContext";
import { Navbar } from "./components/Navbar";
import { Home } from "./components/Home";
import { RecipeDisplay } from "./components/RecipeDisplay";
import { Favorites } from "./components/Favorites";
import { AuthModal } from "./components/AuthModal";
import { NotificationProvider } from "./context/NotificationContext";

const queryClient = new QueryClient();

const App = () => {
  const [isAuthModalOpen, setIsAuthModalOpen] = useState(false);

  return (
    <QueryClientProvider client={queryClient}>
      <NotificationProvider>
        <AuthProvider>
          <div className="min-h-screen w-full bg-orange-50">
            <Router>
              <Navbar onOpenAuthModal={() => setIsAuthModalOpen(true)} />
              <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/recipe/random" element={<RecipeDisplay />} />
                <Route path="/recipe/:recipeId" element={<RecipeDisplay />} />
                <Route path="/favorites" element={<Favorites />} />
              </Routes>
              <AuthModal isOpen={isAuthModalOpen} onClose={() => setIsAuthModalOpen(false)} />
            </Router>
          </div>
        </AuthProvider>
      </NotificationProvider>
    </QueryClientProvider>
  );
};

export default App;
