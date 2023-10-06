import React, { useState } from "react";

export default function NewGame() {
  const [quizInfo, setQuizInfo] = useState({
    name: null,
    description: null,
    stages: [],
  });
  const [stage, setStage] = useState({ topics: [] });

  const [inputValue, setInputValue] = useState(null);

  const [selectedTopic, setSelectedTopic] = useState(null);

  function handleInputChange(event, inputField) {
    if (inputField === "nameField") {
      setQuizInfo({ ...quizInfo, name: event.target.value });
    } else if (inputField === "descriptionField") {
      setQuizInfo({ ...quizInfo, description: event.target.value });
    } else {
      setInputValue(event.target.value);
    }
  }

  function handleSelectChange(event) {
    setSelectedTopic(event.target.value);
  }

  function handleAddTopic() {
    setStage((prevStage) => ({
      topics: [
        ...prevStage.topics,
        { topicName: inputValue, question: null, answers: [] },
      ],
    }));
    setInputValue("");
  }

  function handleAddQuestion() {
    const matchingIndex = stage.topics.findIndex(
      (obj) => obj.topicName === selectedTopic
    );

    const updatedTopics = [...stage.topics];

    updatedTopics[matchingIndex].question = inputValue;

    setStage((prevStage) => ({
      topics: updatedTopics,
    }));

    setInputValue("");
  }

  return (
    <div className="container py-5 px-2">
      <div className="col">
        <div className="d-flex flex-column justify-content-center">
          <div className="mb-5">
            <label className="form-label fs-1">Quiz Name</label>
            <div className="input-group">
              <input
                className="form-control"
                type="text"
                placeholder="Name goes here..."
                onChange={(event) => {
                  handleInputChange(event, "nameField");
                }}
              ></input>
            </div>
          </div>
          <div className="mb-5">
            <label className="form-label fs-2">Description</label>
            <div className="input-group">
              <textarea
                className="form-control"
                placeholder="Description goes here..."
                onChange={(event) => {
                  handleInputChange(event, "descriptionField");
                }}
              ></textarea>
            </div>
          </div>
          <div className="mb-5">
            <label className="fs-3 mb-2">Add Stage</label>
            <div className="d-flex flex-row justify-content-around p-3 border border-2 border-primary-subtle rounded-3">
              <div className="d-flex flex-column justify-content-around">
                <div className="d-flex flex-row mb-5">
                  <div className="d-flex flex-column">
                    <label className="form-label fs-4">Add Topic</label>
                    <div className="input-group">
                      <input
                        className="form-control"
                        type="text"
                        placeholder="Topic name goes here..."
                        onChange={(event) => {
                          handleInputChange(event, "topicField");
                        }}
                      ></input>
                      <button
                        className="d-flex justify-content-center align-items-center btn btn-outline-success"
                        onClick={handleAddTopic}
                      >
                        <span className="material-icons">add</span>
                      </button>
                    </div>
                  </div>
                </div>
                <div className="d-flex flex-row mb-5">
                  <div className="d-flex flex-column">
                    <label className="form-label fs-4">Add Question</label>
                    <select
                      className="form-select mb-3"
                      onChange={handleSelectChange}
                    >
                      <option selected>Choose topic</option>
                      {stage.topics.map((topic) => (
                        <option key={topic.topicName}>{topic.topicName}</option>
                      ))}
                    </select>
                    <div className="input-group">
                      <textarea
                        className="form-control"
                        type="text"
                        placeholder="Question goes here..."
                        onChange={(event) => {
                          handleInputChange(event, "questionField");
                        }}
                      ></textarea>
                      <button
                        className="d-flex justify-content-center align-items-center btn btn-outline-success"
                        onClick={handleAddQuestion}
                      >
                        <span className="material-icons">add</span>
                      </button>
                    </div>
                  </div>
                </div>
              </div>
              <div className="d-flex flex-column justify-content-start align-items-start">
                <div className="fs-3 mb-5 fw-bold">Stage Info</div>
                {stage.topics.length > 0 ? (
                  stage.topics.map((topic) => (
                    <div className="d-flex flex-column fs-4 mb-5">
                      <div className="d-flex flex-row">
                        <span className="me-1">Topic:</span>
                        <span className="text-primary">{topic.topicName}</span>
                      </div>
                      <div className="d-flex flex-row">
                        <span className="me-1">Question:</span>
                        <span className="text-primary">{topic.question}</span>
                      </div>
                      <div className="d-flex flex-row">
                        Answers:{" "}
                        <ul>
                          {topic.answers.map((answer) => (
                            <li>{answer}</li>
                          ))}
                        </ul>
                      </div>
                    </div>
                  ))
                ) : (
                  <div className="fw-bol">
                    Stage is empty... Try creating one!
                  </div>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
