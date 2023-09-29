import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { useState } from "react";
import "./styles.css";
import profile from "./profile.png";

export default function Home() {
  const [formData, setFormData] = useState({
    avatarUrl: "",
    username: "",
  });

  const fetchData = async () => {
    try {
      const avatarResponse = await fetch("https://image.dummyjson.com/150");
      const usernameResponse = await fetch("https://dummyjson.com/users/1");
      if (avatarResponse.ok && usernameResponse.ok) {
        const photo = await avatarResponse.blob();
        const username = await usernameResponse.json();
        const photoUrl = URL.createObjectURL(photo);
        setFormData({
          avatarUrl: photoUrl,
          username: username,
        });
        console.log(photo);
      } else {
        console.log("failed to fetch photo or username");
      }
    } catch (e) {
      console.error("something is wrong", e);
    }
  };
  useEffect(() => {
    fetchData();
    console.log("hi");
  }, []);
  return (
    <div className="d-flex flex-column  justify-content-center align-items-center vh-100">
      <div className=" d-flex flex-row  mb-3 mt-5">
        <img src={profile} />
      </div>
      <div className="mb-5 fs-4 username-text">
        {formData.username.username}
      </div>
      <div className="d-flex flex-row mt-5">
        <div className="mt-5">
          <Link
            to="/settings"
            className="home-page-buttons btn btn-outline-primary me-5 fs-1"
          >
            Settings
          </Link>
        </div>
        <div className="mt-5">
          <Link
            to="/play"
            className=" home-page-buttons btn btn-outline-primary fs-1"
          >
            Play
          </Link>
        </div>
      </div>
    </div>
  );
}
