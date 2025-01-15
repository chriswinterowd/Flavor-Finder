import React, { createContext, useContext, useState, ReactNode } from "react";
import { useNotification } from "./NotificationContext";

interface AuthContextType {
  isAuthenticated: boolean;
  login: (
    username: string,
    password: string,
    rememberMe: boolean
  ) => Promise<{ success: boolean; errors: string[] }>;
  logout: () => Promise<void>;
  register: (
    username: string,
    email: string,
    password: string
  ) => Promise<{ success: boolean; errors: string[] }>;
}

interface LoginRequest {
  Identifier: string;
  Password: string;
  RememberMe: boolean;
}

interface RegisterRequest {
  UserName: string;
  Email: string;
  Password: string;
}
const AuthContext = createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({ children }: { children: ReactNode }) {
  const { showNotification } = useNotification();
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const login = async (
    identifier: string,
    password: string,
    rememberMe: boolean
  ): Promise<{ success: boolean; errors: string[] }> => {
    try {
      const loginRequest: LoginRequest = {
        Identifier: identifier,
        Password: password,
        RememberMe: rememberMe,
      };
      const response = await fetch("http://localhost:5000/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(loginRequest),
      });

      if (response.ok) {
        setIsAuthenticated(true);
        showNotification("Login Successful!");
        return { success: true, errors: [] };
      } else {
        let errorData = await response.json();
        let errors = errorData.errors || ["An unexpected error occured."];
        return { success: false, errors: errors };
      }
    } catch (error) {
      console.error("Login error: ", error);
      return { success: false, errors: ["A network or server error occurred."] };
    }
  };

  const logout = async () => {
    const response = await fetch("http://localhost:5000/api/auth/logout", { method: "POST" });

    if (response.ok) {
      showNotification("Logout Succesful!");
      setIsAuthenticated(false);
    } else {
      showNotification("There was an error when attempting to log out.");
    }
  };

  const register = async (
    username: string,
    email: string,
    password: string
  ): Promise<{ success: boolean; errors: string[] }> => {
    try {
      const registerRequest: RegisterRequest = {
        UserName: username,
        Email: email,
        Password: password,
      };
      const response = await fetch("http://localhost:5000/api/auth/register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(registerRequest),
      });

      if (response.ok) {
        showNotification("Registration Succesful!");
        return { success: true, errors: [] };
      } else {
        let errorData = await response.json();
        let errors = errorData.errors || ["An unexpected error occured."];
        return { success: false, errors };
      }
    } catch (error) {
      console.error("Registration error: ", error);
      return { success: false, errors: ["A network or server error occurred."] };
    }
  };

  return (
    <AuthContext.Provider value={{ isAuthenticated, login, logout, register }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error("useAuth must be used within an AuthProvider");
  return context;
};
