import React, { useState } from "react";
import BookDetails from "./components/BookDetails";
import BlogDetails from "./components/BlogDetails";
import CourseDetails from "./components/CourseDetails";

function App() {
  const [selected, setSelected] = useState("book");

  // 1️⃣ Using if-else
  let content;
  if (selected === "book") {
    content = <BookDetails />;
  } else if (selected === "blog") {
    content = <BlogDetails />;
  } else {
    content = <CourseDetails />;
  }

  return (
    <div className="App" style={{ padding: "20px" }}>
      <h1>📘 Blogger App</h1>

      {/* Menu */}
      <div>
        <button onClick={() => setSelected("book")}>Show Book</button>
        <button onClick={() => setSelected("blog")}>Show Blog</button>
        <button onClick={() => setSelected("course")}>Show Course</button>
      </div>

      <hr />

      {/* 2️⃣ Using element variable */}
      {content}

      {/* 3️⃣ Using ternary operator directly */}
      {/* 
      {selected === "book" ? (
        <BookDetails />
      ) : selected === "blog" ? (
        <BlogDetails />
      ) : (
        <CourseDetails />
      )}
      */}

      {/* 4️⃣ Using short-circuit rendering (optional for true only) */}
      {/* {selected === "course" && <CourseDetails />} */}
    </div>
  );
}

export default App;
