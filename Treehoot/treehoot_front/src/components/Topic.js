import React, { useState } from "react";
import Answer from "./Answer";

export default function Topic(props) {
  const topic = props.topic;

  const [currentTopic, setCurrentTopic] = useState({
    topicName: "",
    question: "",
    answers: [],
  });

  const [answer, setAnswer] = useState("");

  const handleInputChange = (e, field) => {
    const updatedTopic = { ...currentTopic };

    switch (field) {
      case "topicNameField":
        updatedTopic.topicName = e.target.value;
        break;
      case "questionField":
        updatedTopic.question = e.target.value;
        break;
      case "answerField":
        setAnswer(e.target.value);
    }

    setCurrentTopic(updatedTopic);
  };

  const handleUpdateTopic = () => {
    props.updateTopic(currentTopic, props.index);
  };

  const handleAddAnswer = () => {
    if (
      currentTopic.answers.length < 4 &&
      answer.length > 0 &&
      currentTopic.topicName.length > 0 &&
      currentTopic.question.length > 0
    ) {
      const updatedTopic = {
        ...currentTopic,
        answers: [...currentTopic.answers, { answer: answer, isCorrect: "" }],
      };

      setCurrentTopic(updatedTopic);
      props.updateTopic(updatedTopic, props.index);
      setAnswer("");
    } else return;
  };

  const handleIsAnswerCorrectChange = (index) => {
    const updatedAnswers = currentTopic.answers.map((answer, i) => {
      return { ...answer, isCorrect: i === index };
    });

    const updatedTopic = {
      ...currentTopic,
      answers: updatedAnswers,
    };

    setCurrentTopic(updatedTopic);
    props.updateTopic(updatedTopic, props.index);
  };
  return (
    <div className="d-flex flex-column justify-content-centermb-2 border border-secondary-subtle shadow-sm rounded-3 px-3 py-2 mb-4">
      <div className="d-flex flex-row flex-grow-1 justify-content-end align-items-start mb-3">
        <button className="d-flex btn btn-outline-secondary btn-sm p-1">
          <span className="material-icons">remove</span>
        </button>
      </div>
      <div className="d-flex flex-column justify-content-start">
        <div className="d-flex align-items-center mb-2">
          <span className="me-1 fw-bold">Topic:</span>
          {topic.topicName.length > 0 ? (
            <span>{topic.topicName}</span>
          ) : (
            <div className="input-group">
              <input
                placeholder="Topic goes here..."
                type="text"
                className="form-control"
                onChange={(e) => {
                  handleInputChange(e, "topicNameField");
                }}
              />
              <button
                className="d-flex justify-content-center align-items-center btn btn-outline-success p-1"
                onClick={handleUpdateTopic}
              >
                <span className="material-icons">done</span>
              </button>
            </div>
          )}
        </div>
        <div className="d-flex align-items-center mb-2">
          <span className="me-1 fw-bold">Question:</span>
          {topic.question.length > 0 ? (
            <span>{topic.question}</span>
          ) : (
            <div className="input-group">
              <textarea
                placeholder="Question goes here..."
                type="text"
                className="form-control"
                onChange={(e) => {
                  handleInputChange(e, "questionField");
                }}
              />
              <button
                className="d-flex justify-content-center align-items-center btn btn-outline-success p-1"
                onClick={handleUpdateTopic}
              >
                <span className="material-icons">done</span>
              </button>
            </div>
          )}
        </div>
        <div className="d-flex flex-column mb-2">
          <div className="d-flex flex-row align-items-center">
            <span className="me-1 fw-bold">Answers:</span>
            <div className="input-group">
              <input
                placeholder="Question goes here..."
                type="text"
                className="form-control"
                value={answer}
                onChange={(e) => {
                  handleInputChange(e, "answerField");
                }}
              />
              <button
                className="d-flex justify-content-center align-items-center btn btn-success p-1"
                onClick={handleAddAnswer}
              >
                <span className="material-icons">add</span>
              </button>
            </div>
          </div>
          <div>
            <div className="form-check">
              {topic.answers.length > 0 ? (
                topic.answers.map((answer, index) => (
                  <Answer
                    key={index}
                    answer={answer.answer}
                    index={index}
                    topic={topic}
                    updateIsCorrect={handleIsAnswerCorrectChange}
                  />
                ))
              ) : (
                <span className="fw-light fs-6">Try adding question...</span>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
