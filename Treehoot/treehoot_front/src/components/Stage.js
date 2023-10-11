import React, { useState } from "react";
import Topic from "../components/Topic";

export default function Stage(props) {
  const stage = props.stage;
  const updateTopic = props.updateTopic; //update topic function from NewGame component

  const handleAddTopic = () => {
    if (stage.topics.length < 4)
      props.handleAddTopic({
        topicName: "",
        question: "",
        answers: [],
      });
  };

  return (
    <div className="border border-primary-subtle border-2 rounded-3 p-2 m-3 shadow">
      <div className="d-flex flex-column justify-content-center align-items-start px-2">
        <div className="d-flex justify-content-start mb-3 fs-3">
          <span>{stage.name}</span>
        </div>
        <div className="d-flex flex-column justify-content-start mb-2 fs-4">
          <div className="d-flex flex-row mb-3">
            <span className="me-3">Topics: </span>
            <button
              className="d-flex btn btn-outline-success"
              onClick={handleAddTopic}
            >
              <span className="material-icons me-1">add</span>
              <span className="">Add Topic</span>
            </button>
          </div>
          <div>
            <ul className="fs-5">
              {stage.topics.length > 0 ? (
                stage.topics.map((topic, index) => (
                  <Topic
                    updateTopic={updateTopic}
                    index={index}
                    topic={topic}
                    key={index}
                  />
                ))
              ) : (
                <span className="fs-5 fw-light">Try adding one...</span>
              )}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
}
