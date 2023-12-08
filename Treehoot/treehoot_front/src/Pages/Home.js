import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { useState } from "react";
import "../styles.css";
import profile from "../Pictures/profile.png";
import LoadingCircle from "../components/LoadingCircle";
import { useUser } from "../UserContext";

export default function Home() {
  const [formData, setFormData] = useState({
    avatarUrl: "",
    username: "",
  });
  const [loading, setLoading] = useState(true);
  const { user } = useUser();

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
        setLoading(false);
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
      <div className="mb-5 fs-4 text">
        {loading ? (
          <div style={{ height: "4rem" }}>
            <LoadingCircle />
          </div>
        ) : (
          <div style={{ height: "4rem" }}>{formData.username.username}</div>
        )}
      </div>
      <div className="d-flex flex-row mt-5 gap-5">
        <div className="mt-5 ">
          <Link
            to="/settings"
            className="home-page-buttons btn btn-outline-primary fs-2"
          >
            Settings
          </Link>
        </div>
        <div className="mt-5">
          <Link
            to="/play"
            className=" home-page-buttons btn btn-outline-primary fs-2"
          >
            Play
          </Link>
        </div>
        <div className="mt-5">
          <Link
            to="/new-game"
            className="home-page-buttons btn btn-outline-primary fs-2 "
          >
            New Game
          </Link>
        </div>
        <div className="mt-5">
          {user.isLoggedIn ? (
            <button className="home-page-buttons btn btn-outline-primary fs-2">
              Log out
            </button>
          ) : (
            <Link
              to="/log-in"
              className="home-page-buttons btn btn-outline-primary fs-2"
            >
              Log in
            </Link>
          )}
        </div>
      </div>
    </div>
  );
}
