import { createContext, useContext, useEffect, useState } from "react";

const USER_STORAGE_KEY = "user";

const INITIAL_STATE = {
  username: "Anonymous",
  isLoggedIn: false,
  score: 0,
};

const UserContext = createContext();

export const useUser = () => {
  return useContext(UserContext);
};

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(() => {
    // Initialize state from localStorage or use the INITIAL_STATE if not present
    const storedUser = localStorage.getItem(USER_STORAGE_KEY);
    return storedUser ? JSON.parse(storedUser) : INITIAL_STATE;
  });

  const login = (userData) => {
    setUser(userData);
  };

  const logout = () => {
    setUser(INITIAL_STATE);
  };

  const calculateScore = (isCorrect) => {
    isCorrect
      ? setUser((prev) => ({ ...prev, score: user.score + 1 }))
      : setUser((prev) => ({ ...prev, score: user.score - 1 }));
    console.log("answered!");
  };

  const endGame = () => {
    setUser((prev) => ({ ...prev, score: 0 }));
  };

  useEffect(() => {
    // Save user information to localStorage whenever it changes
    localStorage.setItem(USER_STORAGE_KEY, JSON.stringify(user));
  }, [user]);

  return (
    <UserContext.Provider
      value={{ user, login, logout, calculateScore, endGame }}
    >
      {children}
    </UserContext.Provider>
  );
};
