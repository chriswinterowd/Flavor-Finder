import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./components/Home";
import RecipeDisplay from "./components/RecipeDisplay";

const App = () => {
  return (
    <div className="min-h-screen w-full bg-orange-50">
      <Router>
        <Navbar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/recipe" element={<RecipeDisplay />} />
        </Routes>
      </Router>
    </div>
  );
};

export default App;
