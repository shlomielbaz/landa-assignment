import React, { Component, useContext, useEffect, useState } from "react";
import Dashboard from "./Dashboard";

import LayoutContext from "../contexts/layout.context";
import { Layout } from "react-grid-layout";

const Home = () => {
  const store = useContext(LayoutContext);
  const [layout, setLayout] = useState(store.layout);

  useEffect(() => {

  }, [])
  
  return (
    <React.Fragment>
      {/* <button onClick={add}>Add</button> */}
      <Dashboard 
        layout={layout.map((item: Layout) => ({
          ...item,
          static: true
        }))}
        cols={12}
        maxRows={8}
        preventCollision={true}
      />
    </React.Fragment>
  )
}
export default Home;