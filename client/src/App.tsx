import React, { useState } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Navbar } from "./components/Navbar";
import { Home } from "./components/Home";
import { RecipeDisplay } from "./components/RecipeDisplay";
import { AuthModal } from "./components/AuthModal";

const App = () => {
  const [isAuthModalOpen, setIsAuthModalOpen] = useState(false);

  return (
    <div className="min-h-screen w-full bg-orange-50">
      <Router>
        <Navbar onOpenAuthModal={() => setIsAuthModalOpen(true)} />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/recipe" element={<RecipeDisplay />} />
        </Routes>
        <AuthModal
          isOpen={isAuthModalOpen}
          onClose={() => setIsAuthModalOpen(false)}
        />
      </Router>
    </div>
  );
};

export default App;
