import React, { useEffect, useReducer } from "react";
import Timer from "./Timer";
import { reducer, INITIAL_STATE } from "../Reducers/FetchDataReducer";
import LoadingCircle from "../LoadingCircle";

export default function Question() {
  const [state, dispatch] = useReducer(reducer, INITIAL_STATE);

  const fetchData = async () => {
    try {
      //dummy json data for testing purposes
      const url = "https://dummyjson.com/carts";
      const response = await fetch(url);
      if (response.ok) {
        const responseData = await response.json();
        dispatch({ type: "SET_DATA", payload: responseData });
        dispatch({ type: "NOT_LOADING" });
      } else {
        dispatch({ type: "NOT_LOADING" });
        dispatch({ type: "SET_ERROR", payload: response });
      }
    } catch (error) {
      dispatch({ type: "SET_ERROR", payload: error });
      dispatch({ type: "NOT_LOADING" });
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  return (
    <div className="d-flex flex-row justify-content-center align-items-center p-5 border border-3 border-primary-subtle rounded-4">
      {!state.isLoading ? (
        state.data ? (
          <div className="d-flex flex-column justify-content-between align-items-center">
            <div className="d-flex flex-row mb-3 mt-3">
              {/* Going to pass time from questionInfo object */}
              <Timer timeLeft={10} />
            </div>
            <div className="d-flex flex-row mb-3 mt-3">
              <span className="fs-2">
                {/* Display question from fetched data */}
                Hello, how's your day?
              </span>
            </div>
            <div className="d-flex flex-row mb-5 mt-3">
              {/* Display image from fetched data */}
              <img
                src="https://media.istockphoto.com/id/1486505577/photo/question-mark-on-green-background.webp?b=1&s=170667a&w=0&k=20&c=wWkJyJJ_cWmT5zeZ3VYMLXL1v0EoJK7DynrngmLjE0I="
                alt="Image for question"
                style={{ width: "35rem" }}
              />
            </div>
            <div className="d-flex flex-row justify-content-between align-items-center mb-3 mt-3">
              {/* Map buttons with answers */}
              <button className="btn btn-outline-danger btn-lg me-5">
                Good
              </button>
              <button className="btn btn-outline-danger btn-lg me-5">
                Not Bad
              </button>
              <button className="btn btn-outline-danger btn-lg me-5">
                Not Good
              </button>
              <button className="btn btn-outline-danger btn-lg">Bad</button>
            </div>
          </div>
        ) : (
          <span className="fs-3">
            {typeof state.errorMessage === "string"
              ? state.errorMessage
              : "An error has occured!"}
          </span>
        )
      ) : (
        <LoadingCircle />
      )}
    </div>
  );
}
