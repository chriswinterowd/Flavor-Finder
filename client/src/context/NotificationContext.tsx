import React, { createContext, useContext, useState, ReactNode } from "react";
import { Toast } from "../components/Toast";

interface NotificationContextType {
  showNotification: (msg: string) => void;
}

const NotificationContext = createContext<NotificationContextType | undefined>(undefined);

export function NotificationProvider({ children }: { children: ReactNode }) {
  const [message, setMessage] = useState<string | null>(null);

  const showNotification = (msg: string) => {
    setMessage(msg);

    setTimeout(() => setMessage(null), 3000);
  };

  const handleClose = () => setMessage(null);

  return (
    <NotificationContext.Provider value={{ showNotification }}>
      {children}
      {message && <Toast message={message} onClose={handleClose} />}
    </NotificationContext.Provider>
  );
}

export const useNotification = () => {
  const context = useContext(NotificationContext);

  if (!context) {
    throw new Error("useNotification must be used within a NotificationProvider");
  }

  return context;
};
