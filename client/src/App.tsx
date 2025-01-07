import React from 'react';
import Navbar from './components/Navbar';
import Home from './components/Home';

const App = () => {
  return (
    <div className="min-h-screen w-full bg-orange-50">
      <Navbar />
      <Home />
    </div>
  );
};

export default App;
