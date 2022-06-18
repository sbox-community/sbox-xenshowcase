// Created by Crowbar 0.71

$modelname "props_xen\c4a1a\intro_nihilanth.mdl"

$bodygroup "body"
{
	studio "nihilanth_c4a1a_intro_ref.smd"
}


$surfaceprop "default"

$contents "solid"

$illumposition 3.859 -79.615 261.295

$cdmaterials "models\xenians\nihilanth\"

$attachment "cameraParent" "cameraParent" 0 0 -7.5 rotate 90 90 0

$cbox 0 0 0 0 0 0

$bbox -426.319 -399.618 -322.759 585.55 407.337 845.349

$definebone "Pelvis" "" 0 -9.51208 76.037697 10.627049 168.163683 12.301231 0 0 0 0 0 0
$definebone "Spine_1" "Pelvis" -11.8941 -23.599104 25.808205 -81.077542 162.425518 31.209528 0 0 0 0 0 0
$definebone "Spine_2" "Spine_1" 76.735199 0 0 0.000001 13.216875 0 0 0 0 0 0 0
$definebone "Arm_Upper_Center" "Spine_2" -46.705597 -120.706017 13.655202 -0.000001 -147.012377 0 0 0 0 0 0 0
$definebone "Arm_Lower_Center" "Arm_Upper_Center" 113.944023 0.000015 0.000001 0 54.761069 -0.000001 0 0 0 0 0 0
$definebone "Arm_Center_Hand" "Arm_Lower_Center" 121.88501 -0.000008 0.000001 0 -16.370949 0 0 0 0 0 0 0
$definebone "Finger_Center_L_1" "Arm_Center_Hand" 0 0 0 21.84155 19.899801 0.062412 0 0 0 0 0 0
$definebone "Finger_Center_L_2" "Finger_Center_L_1" 71.906128 -0.000011 0.000015 -0.835459 -8.265372 -0.039951 0 0 0 0 0 0
$definebone "Finger_Center_L_3" "Finger_Center_L_2" 29.748596 0.000168 0.000008 -0.000004 -33.409976 0.000003 0 0 0 0 0 0
$definebone "Finger_Center_L_4" "Finger_Center_L_3" 50.572601 0 0 -0.000001 -27.313761 0.000002 0 0 0 0 0 0
$definebone "Finger_Center_R_1" "Arm_Center_Hand" 0 0 0 -21.843614 19.901634 179.937973 0 0 0 0 0 0
$definebone "Finger_Center_R_2" "Finger_Center_R_1" 71.905975 -0.000002 -0.000015 -0.414103 8.199424 2.144466 0 0 0 0 0 0
$definebone "Finger_Center_R_3" "Finger_Center_R_2" 29.748627 -0.000206 0.000122 0.000002 33.409802 0 0 0 0 0 0 0
$definebone "Finger_Center_R_4" "Finger_Center_R_3" 50.572601 -0.000031 0 0.000002 27.313643 0 0 0 0 0 0 0
$definebone "Hand_Center" "Arm_Center_Hand" 0 0 0 -0.000001 -33.55745 0 0 0 0 0 0 0
$definebone "Thumb_Center_1" "Hand_Center" 81.255203 0.000031 0.000001 -0.000001 10.766736 0 0 0 0 0 0 0
$definebone "Spine_3" "Spine_2" 71.100311 -0.000011 0 0.000001 -14.888651 0 0 0 0 0 0 0
$definebone "Clavicle_L" "Spine_3" 66.138504 0.000004 0 80.678194 171.983016 90.000214 0 0 0 0 0 0
$definebone "Upper_Arm_L" "Clavicle_L" 121.281998 -0.000336 0.000008 2.123879 16.498032 0.615552 0 0 0 0 0 0
$definebone "Lower_Arm_L" "Upper_Arm_L" 179.722992 0.000122 -0.001198 17.800714 -6.695529 -0.790028 0 0 0 0 0 0
$definebone "Hand_L" "Lower_Arm_L" 160.513 0.000336 0.00013 4.394034 1.835458 98.859858 0 0 0 0 0 0
$definebone "Finger_L_L_1" "Hand_L" 94.093689 -31.271698 -2.50235 17.308767 -22.847097 5.134663 0 0 0 0 0 0
$definebone "Finger_L_L_2" "Finger_L_L_1" 57.077515 0 -0.000031 16.620994 4.984422 1.374532 0 0 0 0 0 0
$definebone "Finger_L_L_3" "Finger_L_L_2" 55.20668 0.000031 -0.000031 9.479532 -5.497794 -0.855249 0 0 0 0 0 0
$definebone "Finger_L_R_1" "Hand_L" 88.550903 18.148209 -1.535065 23.028324 15.31665 -5.189831 0 0 0 0 0 0
$definebone "Finger_L_R_2" "Finger_L_R_1" 68.095978 0 0 12.207615 0.021513 -0.08396 0 0 0 0 0 0
$definebone "Finger_L_R_3" "Finger_L_R_2" 47.843872 -0.000004 -0.000031 6.085216 -0.466419 -0.145785 0 0 0 0 0 0
$definebone "Thumb_L_1" "Hand_L" 36.719238 -47.744186 -28.368011 24.365257 -53.086371 8.513121 0 0 0 0 0 0
$definebone "Thumb_L_2" "Thumb_L_1" 52.456905 0 -0.002716 -0.000003 31.891055 0.000002 0 0 0 0 0 0
$definebone "Lower_Arm_L_Twist" "Lower_Arm_L" 65.982697 3.578125 1.839714 -1.593718 3.103841 96.339989 0 0 0 0 0 0
$definebone "Upper_Arm_L_Twist" "Upper_Arm_L" 90.9552 1.805023 0.018509 -0.011166 1.136413 89.994484 0 0 0 0 0 0
$definebone "Clavicle_R" "Spine_3" 66.138504 0.000004 0 -80.678194 171.983016 90.000214 0 0 0 0 0 0
$definebone "Upper_Arm_R" "Clavicle_R" 121.28199 0.000244 0 0.843687 -14.613116 -0.866312 0 0 0 0 0 0
$definebone "Lower_Arm_R" "Upper_Arm_R" 179.722992 0 -0.001244 16.931189 6.119304 0.575135 0 0 0 0 0 0
$definebone "Hand_R" "Lower_Arm_R" 183.643967 0.447876 -3.404411 5.224722 0.669123 -98.528115 0 0 0 0 0 0
$definebone "Finger_R_L_1" "Hand_R" 96.076172 34.362411 -2.630829 22.827961 22.260731 -5.336099 0 0 0 0 0 0
$definebone "Finger_R_L_2" "Finger_R_L_1" 57.077545 0 0 16.620939 -4.984468 -1.374528 0 0 0 0 0 0
$definebone "Finger_R_L_3" "Finger_R_L_2" 55.206787 0 0.000031 9.479652 5.497954 0.855273 0 0 0 0 0 0
$definebone "Finger_R_R_1" "Hand_R" 84.418396 -15.82608 -1.88623 25.709022 -15.046451 5.301399 0 0 0 0 0 0
$definebone "Finger_R_R_2" "Finger_R_R_1" 68.09613 -0.000004 0 12.207733 -0.021477 0.083953 0 0 0 0 0 0
$definebone "Finger_R_R_3" "Finger_R_R_2" 47.843994 0 0.000122 6.08516 0.466389 0.14581 0 0 0 0 0 0
$definebone "Thumb_R_1" "Hand_R" 36.249878 54.133896 -27.679474 24.365202 53.086375 -8.51312 0 0 0 0 0 0
$definebone "Thumb_R_2" "Thumb_R_1" 52.456909 0.000092 -0.002747 0 -31.891055 0 0 0 0 0 0 0
$definebone "Lower_Arm_R_Twist" "Lower_Arm_R" 66.095169 -0.801239 0.829224 -0.7243 -0.671489 -96.196746 0 0 0 0 0 0
$definebone "Upper_Arm_R_Twist" "Upper_Arm_R" 90.955193 -1.804962 0.018456 -0.011147 -1.136374 -89.994484 0 0 0 0 0 0
$definebone "Neck_1" "Spine_3" 66.138596 0.000233 0 0 -46.262903 -0.000001 0 0 0 0 0 0
$definebone "Head_1" "Neck_1" 99.838989 0 0.000001 0 0 -0.000001 0 0 0 0 0 0
$definebone "Eyelid_L_Down" "Head_1" 110.040009 -75.545715 -44.7033 -0.000001 -81.754202 -90.000207 0 0 0 0 0 0
$definebone "Eyelid_L_Up" "Head_1" 110.040009 -75.545715 -44.7033 0 -41.754189 -90.000207 0 0 0 0 0 0
$definebone "Eyelid_R_Down" "Head_1" 110.040009 -75.54599 72.003006 -0.000001 -86.754406 -90.000207 0 0 0 0 0 0
$definebone "Eyelid_R_Up" "Head_1" 110.040009 -75.54599 72.003006 0 -46.754216 -90.000207 0 0 0 0 0 0
$definebone "Eye_Center" "Head_1" 189.62204 -114.550003 13.6552 -0.000001 -51.754187 -90.000207 0 0 0 0 0 0
$definebone "Eye_Lower_L" "Head_1" 96.642639 -120.764992 -51.344902 -0.000001 -51.754246 -90.000207 0 0 0 0 0 0
$definebone "Eye_Lower_R" "Head_1" 96.642517 -120.764992 78.65519 -0.000001 -51.754246 -90.000207 0 0 0 0 0 0
$definebone "Eye_Upper_L" "Head_1" 135.035034 -90.502808 -86.344795 -0.000001 -51.754187 -90.000207 0 0 0 0 0 0
$definebone "Eye_Upper_R" "Head_1" 135.035034 -90.502716 123.655006 -0.000001 -51.754246 -90.000207 0 0 0 0 0 0
$definebone "Eyeball_L" "Head_1" 110.040009 -75.545715 -44.7033 -0.000001 -62.360153 -90.000207 0 0 0 0 0 0
$definebone "Eyeball_R" "Head_1" 110.040009 -75.54599 72.003006 -0.000001 -62.360153 -90.000207 0 0 0 0 0 0
$definebone "Flap_Back_L_1" "Head_1" -27.455994 140.169998 -75.171707 13.43861 54.995297 -43.018133 0 0 0 0 0 0
$definebone "Flap_Back_L_2" "Flap_Back_L_1" 229.792114 0.000008 -0.000005 1.729193 -39.72408 -0.924786 0 0 0 0 0 0
$definebone "Flap_Back_R_1" "Head_1" -27.456085 140.169998 108.291992 -13.438608 54.9953 -136.981602 0 0 0 0 0 0
$definebone "Flap_Back_R_2" "Flap_Back_R_1" 229.791992 -0.00013 0.000008 1.729162 39.724076 0.924801 0 0 0 0 0 0
$definebone "Flap_Front_1" "Head_1" 263.068024 -94.193512 13.6553 0 39.918255 -0.000001 0 0 0 0 0 0
$definebone "Flap_Front_2" "Flap_Front_1" 217.552979 -0.000122 -0.000002 0.000001 38.357806 0 0 0 0 0 0 0
$definebone "Mouth_Lower" "Head_1" 49.40802 -112.565002 13.6551 -0.000001 -81.111925 0 0 0 0 0 0 0
$definebone "Mouth_Upper" "Head_1" 67.162018 -120.619995 13.6552 0 -32.314124 -0.000001 0 0 0 0 0 0
$definebone "Upper_Leg_L" "Pelvis" -94.593307 -51.100204 -28.377403 77.075994 109.057931 -14.112463 0 0 0 0 0 0
$definebone "Lower_Leg_L" "Upper_Leg_L" 123.085014 -0.000008 0 38.616725 -2.571074 19.973995 0 0 0 0 0 0
$definebone "Leg_L_Nub" "Lower_Leg_L" 141.971008 0.000015 -0.000122 11.322622 -1.955104 -3.897139 0 0 0 0 0 0
$definebone "Upper_Leg_R" "Pelvis" 111.195 -0.000002 0.000008 69.248255 52.9024 -33.550063 0 0 0 0 0 0
$definebone "Lower_Leg_R" "Upper_Leg_R" 123.085007 0.000008 0.000008 38.616728 2.571073 -19.973941 0 0 0 0 0 0
$definebone "Leg_R_Nub" "Lower_Leg_R" 141.970978 0.000015 -0.000187 11.322625 1.955081 3.897071 0 0 0 0 0 0
$definebone "cameraParent" "" 0.242241 -364.255005 250.141998 0 0 90.000207 0 0 0 0 0 0


$sectionframes 30 370

$sequence "interdimensional" {
	"intro_nihilanth_anims\interdimensional.smd"
	fadein 0.2
	fadeout 0.2
	fps 30
	loop
}

$sequence "idle" {
	"intro_nihilanth_anims\idle.smd"
	fadein 0.2
	fadeout 0.2
	fps 1
	loop
}
