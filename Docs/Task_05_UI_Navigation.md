# Task 05 – UI Navigation Logic Implementation

# Objective
To demonstrate structured UI logic handling by activating placeholder panels based on bottom bar button interactions in the HomeScreen scene.

# Approach
Since the original HomeScreen scene had a working bottom bar but no functional navigation or content panels, I added three animated panels: `ShopPanel`, `HomePanel`, and `MapPanel`.

These panels are now toggled based on the selected button using an improved controller logic in `MenuFooterController.cs`. The panels use the same smooth scale-in/out animations that were used in the original `SettingsPopup`.

# Scene Hierarchy Changes
- Created a new `PanelsRoot` under `Canvas > Content`
  - Added:
    - `ShopPanel`
    - `HomePanel`
    - `MapPanel`
- Each panel is based on a duplicate of `SettingsPopup` (for reuse of animation and layout).
- Removed or deactivated the blocking `Background` overlay that interfered with button interactions.
- Renamed `SettingsPopupController.cs` to `GenericPopupController.cs` and moved it to `Shared/Scripts`.

## Code Changes – MenuFooterController.cs
```csharp
[SerializeField] private GenericPopupController shopPanel;
[SerializeField] private GenericPopupController homePanel;
[SerializeField] private GenericPopupController mapPanel;

[SerializeField] private ButtonFooterController shopButton;
[SerializeField] private ButtonFooterController homeButton;
[SerializeField] private ButtonFooterController mapButton;

private void ShowPanel(ButtonFooterController clickedButton)
{
    shopPanel.Hide();
    homePanel.Hide();
    mapPanel.Hide();

    if (clickedButton == shopButton) shopPanel.Show();
    if (clickedButton == homeButton) homePanel.Show();
    if (clickedButton == mapButton) mapPanel.Show();
}
```

## Visual Confirmation
# Initial State (on load, no panels shown)
![InitialState](Screenshot_Task05_InitialState.png)

## After clicking Shop Button
![ShopPanelActive](Screenshot_Task05_ShopPanelActive.png)

# Outcome
- Clicking bottom bar buttons now shows the related panel with animation.
- Game starts with no panel open, and users manually navigate via footer.
- UI logic is centralized and scalable for future panel additions.

---
# Files Modified
- `HomeScreen.unity`
- `MenuFooterController.cs`
- `GenericPopupController.cs` (renamed + reused)