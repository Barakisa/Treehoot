import React, { useState } from "react";

export default function AnswerModal(props) {
  const [inputValue, setInputValue] = useState({
    answer: null,
    isCorrect: null,
  });
  const [isInputValid, setIsInputValid] = useState(false);

  const [selectedOption, setSelectedOption] = useState("no");

  function inputValueChange(e) {
    if (e.target.value.length > 0) {
      setIsInputValid(true);
      setInputValue({ ...inputValue, answer: e.target.value });
    } else setIsInputValid(false);
  }

  function handleOptionChange(e) {
    setSelectedOption(e.target.value);
  }

  function handleFormSubmit(e) {
    e.preventDefault();
    if (isInputValid) {
      setInputValue({ ...inputValue, isCorrect: selectedOption });
    }
  }

  return (
    <div
      className="modal fade"
      id="answerModal"
      data-bs-backdrop="static"
      data-bs-keyboard="false"
      tabIndex="-1"
      aria-labelledby="staticBackdropLabel"
      aria-hidden="true"
    >
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h1 className="modal-title fs-5" id="staticBackdropLabel">
              Enter the answer details
            </h1>
            <button
              type="button"
              className="btn-close"
              data-bs-dismiss="modal"
              aria-label="Close"
            ></button>
          </div>
          <form
            className="needs-validation"
            onSubmit={handleFormSubmit}
            noValidate
          >
            <div className="modal-body">
              <div className="input-group has-validation">
                <input
                  className="form-control mb-3"
                  placeholder="Answer goes here..."
                  type="text"
                  required
                  onChange={inputValueChange}
                />
                <div class="invalid-feedback">This field can't be empty</div>
              </div>
              <div className="d-flex flex-column justify-content-around fs-5">
                Is the answer correct?
                <div className="form-check fs-6">
                  <input
                    className="form-check-input"
                    type="radio"
                    name="isCorrectCheckbox"
                    id="isCorrectCheckboxYes"
                    value="yes"
                    onChange={handleOptionChange}
                    checked={selectedOption === "yes"}
                  />
                  <label className="form-check-label">Yes</label>
                </div>
                <div className="form-check fs-6">
                  <input
                    className="form-check-input"
                    type="radio"
                    name="isCorrectCheckbox"
                    id="isCorrectCheckboxNo"
                    value="no"
                    onChange={handleOptionChange}
                    checked={selectedOption === "no"}
                  ></input>
                  <label className="form-check-label">No</label>
                </div>
              </div>
            </div>
            <div className="modal-footer">
              <button
                type="button"
                className="btn btn-secondary"
                data-bs-dismiss="modal"
              >
                Close
              </button>
              <button
                type="submit"
                className="btn btn-outline-success"
                data-bs-dismiss={isInputValid ? "modal" : ""}
              >
                Add
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  );
}
