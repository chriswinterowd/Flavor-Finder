import React from 'react';
import CategoryCard from './CategoryCard.tsx';
import '../styles/Home.css'; // Create styles for the home page

const Home = () => {
  const categories = ['Snack', 'Dinner', 'Lunch', 'Breakfast', 'Dessert'];

  return (
    <div className="home">
      <h1 className="title">Flavor Finder</h1>
      <div className="categories">
        {categories.map((category, index) => (
          <CategoryCard key={index} category={category} />
        ))}
      </div>
    </div>
  );
};

export default Home;
