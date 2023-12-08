import React, { useState } from "react";
import Stage from "../components/Stage";

export default function NewGame() {
  const [quizInfo, setQuizInfo] = useState({
    name: "",
    description: "",
    stages: [],
  });

  const [responseMessage, setResponseMessage] = useState(false);

  const handleInputChange = (e, field) => {
    switch (field) {
      case "quizNameField":
        setQuizInfo({ ...quizInfo, name: e.target.value });
        break;
      case "quizDescriptionField":
        setQuizInfo({ ...quizInfo, description: e.target.value });
        break;
      default:
        setQuizInfo({ ...quizInfo });
    }
  };

  const handleAddStage = () => {
    setQuizInfo({
      ...quizInfo,
      stages: [
        ...quizInfo.stages,
        { name: `Stage ${quizInfo.stages.length + 1}`, topics: [] },
      ],
    });
  };

  const handleAddTopic = (stageIndex, topic) => {
    const updatedStages = [...quizInfo.stages];
    updatedStages[stageIndex].topics.push(topic);

    setQuizInfo({
      ...quizInfo,
      stages: updatedStages,
    });
  };

  const handleUpdateTopic = (updatedTopic, stageIndex, topicIndex) => {
    const updatedStages = [...quizInfo.stages];
    updatedStages[stageIndex].topics[topicIndex] = updatedTopic;

    setQuizInfo({
      ...quizInfo,
      stages: updatedStages,
    });

    console.log(quizInfo);
  };

  const handleCreateQuizSubmit = async () => {
    const url = "https://localhost:7219/api/Quiz";
    const options = {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(quizInfo),
    };

    ///debug
    console.log(options);
    
    try {
      const response = await fetch(url, options);
      const responseData = await response.json();

      
      ///debug
      console.log(responseData);

      if (response.ok) {
        setQuizInfo({
          name: "",
          description: "",
          stages: [],
        });

        setResponseMessage(responseData.message);
      } else {
        console.log("Error (Api)");
        setResponseMessage(responseData.message);
      }
    } catch (error) {
      console.error("Error (TryCatch):", error);
    }
  };

  return (
    <div className="container py-5 px-2">
      <div className="col">
        <div className="d-flex flex-row justify-content-center align-items-center fs-1 mb-4 fw-">
          Create Quiz
        </div>
        <div className="d-flex flex-column justify-content-center mb-5">
          <div className="mb-5">
            <label className="form-label fs-2" for="quizNameField">
              Quiz Name
            </label>
            <input
              className="form-control"
              type="text"
              placeholder="Name goes here..."
              id="quizNameField"
              value={quizInfo.name}
              onChange={(e) => {
                handleInputChange(e, "quizNameField");
              }}
            />
          </div>
          <div className="mb-5">
            <label className="form-label fs-2" for="quizDescriptionField">
              Quiz Description
            </label>
            <textarea
              className="form-control"
              type="text"
              placeholder="Description goes here..."
              id="quizDescriptionField"
              value={quizInfo.description}
              onChange={(e) => {
                handleInputChange(e, "quizDescriptionField");
              }}
            />
          </div>
          <div className="mb-5">
            <button
              className="d-flex justify-content-center align-items-center btn btn-outline-success btn-lg"
              onClick={handleAddStage}
            >
              <span className="material-icons me-1">add</span>
              <span className="">Add Stage</span>
            </button>
          </div>
          <div className="row">
            {quizInfo.stages.map((stage, index) => (
              <div key={stage.name}>
                <Stage
                  stage={stage}
                  handleAddTopic={(topic) => handleAddTopic(index, topic)}
                  updateTopic={(updatedTopic, topicIndex) =>
                    handleUpdateTopic(updatedTopic, index, topicIndex)
                  }
                />
              </div>
            ))}
          </div>
        </div>
        <div className="d-flex flex-column justify-content-center align-items-center">
          <button
            className="btn btn-success btn fs-1 fw-bold mb-2"
            style={{ width: "23rem", height: "6rem" }}
            onClick={handleCreateQuizSubmit}
          >
            Create Quiz
          </button>
          {responseMessage ? (
            <span className="text-danger">{responseMessage}</span>
          ) : (
            ""
          )}
        </div>
      </div>
    </div>
  );
}
