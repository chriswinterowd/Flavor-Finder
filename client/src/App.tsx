import { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { AuthProvider } from "./context/AuthContext";
import { Navbar } from "./components/Navbar";
import { Home } from "./components/Home";
import { RecipeDisplay } from "./components/RecipeDisplay";
import { AuthModal } from "./components/AuthModal";
import { NotificationProvider } from "./context/NotificationContext";

const App = () => {
  const [isAuthModalOpen, setIsAuthModalOpen] = useState(false);

  return (
    <NotificationProvider>
      <AuthProvider>
        <div className="min-h-screen w-full bg-orange-50">
          <Router>
            <Navbar onOpenAuthModal={() => setIsAuthModalOpen(true)} />
            <Routes>
              <Route path="/" element={<Home />} />
              <Route path="/recipe" element={<RecipeDisplay />} />
            </Routes>
            <AuthModal isOpen={isAuthModalOpen} onClose={() => setIsAuthModalOpen(false)} />
          </Router>
        </div>
      </AuthProvider>
    </NotificationProvider>
  );
};

export default App;
