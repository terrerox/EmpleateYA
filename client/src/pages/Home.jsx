import React from 'react'
import { Link, Outlet } from "react-router-dom";

const Home = () => {
    return (
        <>
            <h1>EmpleateYA</h1>
            <nav
                style={{
                borderBottom: "solid 1px",
                paddingBottom: "1rem"
                }}
            >
                <Link to="/jobs">Trabajos</Link> |{" "}
                <Link to="/candidates">Candidatos</Link>
            </nav>
            <main>
                <Outlet />
            </main>
        </>
    )
}

export default Home
