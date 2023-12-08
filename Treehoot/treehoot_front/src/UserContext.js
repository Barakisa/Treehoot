import { createContext, useContext, useState } from "react";

const INITIAL_STATE = {
  user: null,
  isLoggedIn: false,
};

const UserContext = createContext();

export const useUser = () => {
  return useContext(UserContext);
};

export const UserProvider = ({ children }) => {
  const [user, setUser] = useState(INITIAL_STATE);

  const login = (userData) => {
    setUser(userData);
  };

  const logout = () => {
    setUser(INITIAL_STATE);
  };

  return (
    <UserContext.Provider value={{ user, login, logout }}>
      {children}
    </UserContext.Provider>
  );
};
