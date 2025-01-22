import { X } from "lucide-react";

interface ToastProps {
  message: string;
  onClose: () => void;
}

export function Toast({ message, onClose }: ToastProps) {
  return (
    <div className="fixed top-4 left-1/2 transform -translate-x-1/2 bg-orange-500 text-white px-4 py-2 rounded-md shadow-md flex items-center justify-between">
      <span>{message}</span>
      <button onClick={onClose} className="ml-4 text-white font-bold hover:underline">
        <X size={16} />
      </button>
    </div>
  );
}
