import React from "react";

export const INITIAL_STATE = {
  data: null,
  isLoading: true,
  errorMessage: null,
};

export const reducer = (state, action) => {
  switch (action.type) {
    case "NOT_LOADING":
      return {
        ...state,
        isLoading: false,
      };

    case "SET_DATA":
      return {
        ...state,
        data: action.payload,
      };

    case "SET_ERROR":
      return {
        ...state,
        errorMessage: action.payload,
      };

    default:
      return state;
  }
};
