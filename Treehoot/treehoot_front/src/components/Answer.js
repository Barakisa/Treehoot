import React from "react";

export default function Answer(props) {
  const handleRadioButtonChange = () => {
    props.updateIsCorrect(props.index);
  };
  return (
    <div className="py-1 px-3">
      <input
        type="radio"
        className="form-check-input"
        name={"answerRadio" + props.topic.topicName + props.topic.question}
        id={props.index}
        onChange={handleRadioButtonChange}
      />
      <label class="form-check-label" for={props.index}>
        {props.answer}
      </label>
    </div>
  );
}
