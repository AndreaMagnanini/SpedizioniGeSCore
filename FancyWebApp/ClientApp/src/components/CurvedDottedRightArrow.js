// @ts-nocheck
import React from 'react'
import {
    makeStyles,
} from "@material-ui/core";

const useStyles = makeStyles({
    arrowIcon: {
        // transform: "rotate(157deg) translate(-10px, 25px)",
        marginLeft: "-40px",
        marginRight: "-40px",
        marginTop: "-50px",
        marginBottom: "-50px",
        transform: "rotateX(180deg) translate(0, 30px) rotate(3deg)",
    }
});

export default function CurvedDottedRightArrow() {
    const classes = useStyles();
  return (
    <img className={classes.arrowIcon} alt="right arrow" src={require('../assets/arrow-right (1).png')} height="250px" width="250px"></img>
  )
}