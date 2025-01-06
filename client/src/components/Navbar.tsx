import React from 'react';
import '../styles/Navbar.css'; // Create styles for your navbar

const Navbar = () => {
  return (
    <nav className="navbar">
      <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/favorites">Favorites</a></li>
        <li><a href="/login">Login</a></li>
        <li><a href="/signup">Signup</a></li>
      </ul>
    </nav>
  );
};

export default Navbar;
