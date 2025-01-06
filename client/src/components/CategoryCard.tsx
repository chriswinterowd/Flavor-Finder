import React from 'react';
import '../styles/CategoryCard.css'; // Create styles for the category cards

interface CategoryCardProps {
  category: string;
}

const CategoryCard: React.FC<CategoryCardProps> = ({ category }) => {
  return (
    <div className="category-card">
      <span>{category}</span>
    </div>
  );
};

export default CategoryCard;
