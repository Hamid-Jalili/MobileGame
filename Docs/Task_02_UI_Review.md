# Task 02 – UI System & Design Review

## General Overview
The current UI implementation demonstrates a visually appealing, mobile-oriented layout with vibrant colors and intuitive iconography. However, several structural and usability shortcomings were observed.

## Hierarchy & Structure

# Observed:
- UI elements are deeply nested (e.g., `HomeScreen > MainCanvas > MenuFooter > Layout > Button > Content > Icon`), which complicates iteration and dynamic generation.
- Multiple buttons are manually duplicated in the scene rather than instantiated from prefabs.
- TextMeshPro components are used inconsistently — font materials are missing or not linked, leading to runtime warnings (`getFontSharedMaterials not found`).

# Recommended:
- Use prefabs for all reusable UI elements (e.g., bottom nav buttons, toggles).
- Use layout groups (`HorizontalLayoutGroup`, `GridLayoutGroup`) instead of manual positioning.
- Reference font assets centrally using a shared UI style guide or scriptable object config.
- Clean up GameObject names for clarity (e.g., `Button_shop`, `Content_1`).

## UX & Responsiveness
# Observed:
- Several buttons lack interaction feedback (hover, pressed, disabled state).
- Button hitboxes are tightly fitted to icons — risky for smaller screens.
- Navigation lacks transition animations, leading to abrupt scene changes.
- Bottom nav has inconsistent padding and anchoring; not reliably positioned across screen sizes.

# Recommended:
- Add transition animations for screen changes and popups (`DOTween`, Animator).
- Use 9-slice backgrounds or flexible anchors for buttons.
- Use Unity's **Safe Area API** to pad bottom nav elements on notched devices.
- Introduce navigation logic through a centralized controller (`UINavigationService` pattern).

## Design Consistency
# Observed:
- Mixed font usage and text alignment (e.g., center-aligned vs left-aligned).
- PSD reference files use consistent shadow/glow styles not reflected in UI prefab materials.
- Button scale and icon spacing vary by section.

# Recommended:
- Match PSD mockups more closely via:
  - Consistent `padding`, `icon size`, and `label spacing`
  - Unified `font` assignment (`Lato-Black` for body, `Yorkie-SemiBold` for titles)
  - Color and glow effects via a shared UI theme material
- Introduce `UIStyleConfig.cs` or scriptable object to enforce consistency.

# Screenshot Reference
- `Screenshots/HomeScreen_UI_Review.png`
- `Screenshots/BottomNav_Highlight_States.png`

