import React from "react";
import {Header} from "./Header";
import {Container} from "@material-ui/core";
import {Typography} from "@material-ui/core";
export function Home () {
    return (
        <div>
            <Container>
                <Typography color="textPrimary" gutterBottom variant="h2" align="center">
                    React Material UI example
                </Typography>
            </Container>
        </div>
    );
}
