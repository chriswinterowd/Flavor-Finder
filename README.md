# FlavorFinder

FlavorFinder is a web application that enables users to explore and discover random recipes based on their preferred meal type and cuisine. With its clean user interface and robust backend, FlavorFinder makes it simple to find new culinary adventures.

## Features

- **Intuitive and Responsive Design**: Built with TailwindCSS to provide a smooth and user-friendly experience across devices.
- **Random Recipe Generator**: Generate random recipes based on selected meal and cuisine types using the Spoonacular API.
- **Recipe Details Display**: View comprehensive recipe information, including preparation time, servings, ingredients, and step-by-step instructions.
- **Cuisine and Meal Selection**: Choose from a wide variety of cuisine and meal options to tailor the recipe search.
- **Authentication System**: Secure registration, login, and logout functionality using ASP.NET Identity.
- **Dynamic Filters**: Automatically update recipe results based on user-selected filters.
- **Error Handling**: Robust error handling to gracefully manage API errors and user input issues.

## Technologies Used

- **Backend**: ASP.NET Core
- **Frontend**: React.js, styled with TailwindCSS
- **Authentication**: ASP.NET Identity
- **Database**: PostgreSQL, managed with EF Core
- **Version Control**: GitHub

## Screenshots

### Home Page

The home page allows users to select a meal type and cuisine type before generating a random recipe.
<img src="https://i.imgur.com/HuM7J4S.png" width="800px">

### Recipe Details

Detailed view of a recipe, including a summary, ingredients, and cooking instructions.
<img src="https://i.imgur.com/LxFPDFH.png" width="800px">

### Login Modal

Secure login functionality with an intuitive design.
<img src="https://i.imgur.com/MiXN1gR.png" width="800px">

## Installation and Setup

### Local Development

1. **Clone the repository**:
   ```bash
   git clone https://github.com/chriswinterowd/Flavor-Finder.git
   ```
2. **Navigate to the project directory**:
   ```bash
   cd Flavor-Finder
   ```
3. **Backend Setup**:
   - Ensure you have .NET SDK installed.
   - Navigate to the backend folder and restore dependencies:
     ```bash
     cd backend
     dotnet restore
     ```
   - Create or update the `appsettings.json` file with the following required fields:
     ```json
     {
       "Spoonacular": {
         "ApiKey": "YOUR_SPOONACULAR_API_KEY"
       },
       "ConnectionStrings": {
         "DefaultConnection": "YOUR_DATABASE_CONNECTION_STRING"
       }
     }
     ```
   - Replace `YOUR_SPOONACULAR_API_KEY` with your Spoonacular API key.
   - Replace `YOUR_DATABASE_CONNECTION_STRING` with the connection string for your PostgreSQL database.
   - Run the backend server:
     ```bash
     dotnet run
     ```
4. **Frontend Setup**:

   - Navigate to the `client` folder:
     ```bash
     cd client
     ```
   - Install dependencies:
     ```bash
     npm install
     ```
   - Start the development server (powered by Vite):
     ```bash
     npm run dev
     ```

5. **Access the application**:
   - Open your browser and navigate to `http://localhost:5173`.

## Status

FlavorFinder is an ongoing project, and additional features are planned for future development, such as:

- **Favoriting Recipes**: Allow users to save and revisit their favorite recipes.

## License

This project is licensed under the MIT License.
