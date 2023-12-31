import React, { useEffect, useReducer, useState } from "react";
import LoadingCircle from "../components/LoadingCircle";
import ProgressBar from "../components/ProgressBar";
import { useNavigate } from "react-router";
import "../styles.css";
import {
  reducer,
  INITIAL_STATE,
} from "../components/Reducers/FetchDataReducer";
import { useQuiz } from "../QuizContext";
export default function ChooseTopicPage() {
  const remainingTime = 4;

  const [state, dispatch] = useReducer(reducer, INITIAL_STATE);
  const [buttonPairs, setButtonPairs] = useState(null);
  const { currentStage, setChosenQuestion } = useQuiz();

  const navigate = useNavigate();

  const fetchTopics = async () => {
    console.log(currentStage);
    const url = `https://localhost:7219/api/Question/stageId/${currentStage}`;
    const response = await fetch(url);
    try {
      if (response.ok) {
        const responseData = await response.json();
        console.log(responseData);
        dispatch({ type: "SET_DATA", payload: responseData });
        dispatch({ type: "NOT_LOADING" });

        const newButtonPairs = [];
        for (let i = 0; i < responseData.length; i += 2) {
          newButtonPairs.push([responseData[i], responseData[i + 1]]);
        }
        setButtonPairs(newButtonPairs);
      } else {
        dispatch({ type: "SET_ERROR", payload: response });
        dispatch({ type: "NOT_LOADING" });
      }
    } catch (error) {
      dispatch({ type: "SET_ERROR", payload: error });
      dispatch({ type: "NOT_LOADING" });
    }
  };

  useEffect(() => {
    fetchTopics();
    const timeoutId = setTimeout(() => {
      navigate("/question");
    }, remainingTime * 1000 + 500);
    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  const handleRadioChange = (id, name) => {
    setChosenQuestion({ id: id, name: name });
    console.log(id, name);
  };

  return (
    <div style={{ marginTop: 50 }} className="text container text-center">
      {!state.isLoading && state.data ? (
        <div className="col-12 justify-content-center align-items-center">
          <div className="row justify-content-center align-items-center text-center">
            <div className="py-5 fs-1">
              Choose your topic! Otherwise we will choose it for you :)
            </div>
            <div className="d-flex justify-content-center">
              <ProgressBar remainingTime={remainingTime} />
            </div>
          </div>
          <div className="row m-5">
            {/* Leave for now!
            buttonPairs.map((buttonPair) => (
              <div
                className="d-flex justify-content-start align-items-center"
                key={buttonPair[0].id}
              >
                {buttonPair.map((button) => (
                  <div className="col-xxl-6 m-5" key={button.id}>
                    <div className="d-flex form-check fs-2 justify-content-start align-items-center">
                      <input
                        className="form-check-input me-4"
                        type="radio"
                        name="topicRadio"
                        id={`topicRadio${button.id}`}
                      />
                      <label
                        className="form-check-label text-break text-start"
                        for={`topicRadio${button.id}`}
                      >
                        {button.topic}
                      </label>
                    </div>
                  </div>
                ))}
              </div>
                ))*/}
            {state.data.map((button) => (
              <div
                className="col-xxl-6 col-xl-6 col-lg-6 col-md-12 justify-content-center p-4"
                key={button.id}
              >
                <div className="d-flex form-check fs-2 justify-content- align-items-center">
                  <input
                    className="form-check-input me-4"
                    type="radio"
                    name="topicRadio"
                    id={`topicRadio${button.id}`}
                    style={{ cursor: "pointer" }}
                    onChange={() =>
                      handleRadioChange(button.id, button.questionText)
                    }
                  />
                  <label
                    className="form-check-label text-break text-start"
                    for={`topicRadio${button.id}`}
                    style={{ cursor: "pointer" }}
                  >
                    {button.topic}
                  </label>
                </div>
              </div>
            ))}
          </div>
        </div>
      ) : (
        <div className="p-5">
          <LoadingCircle />
        </div>
      )}
    </div>
  );
}
