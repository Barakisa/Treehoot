import React from "react";
import { Link } from "react-router-dom";
import "../styles.css";

export default function Join() {
  return (
    <div className=" d-flex flex-column align-items-center justify-content-center vh-100">
      <div>
        <input placeHolder=" Enter game code" className="input-box" />
      </div>
      <div>
        <Link
          to="/question_preview"
          className="home-page-buttons btn btn-outline-primary fs-2 mt-5"
        >
          Confirm
        </Link>
      </div>
    </div>
  );
}
